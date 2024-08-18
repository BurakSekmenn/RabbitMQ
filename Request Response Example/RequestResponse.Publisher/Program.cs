using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

string requestQueueName = "example-request-response-queue";
channel.QueueDeclare(
    queue: requestQueueName,
    durable: false,
    exclusive: false,
    autoDelete: false
    );

// Response queue oluşturuluyoruz
string replyQueueName = channel.QueueDeclare().QueueName;


string correlationId = Guid.NewGuid().ToString(); // correlationId oluşturuluyoruz. // Request ve Response mesajlarını eşleştirmek için kullanılır.


#region Request Mesajını oluşturma Ve Gönderme
IBasicProperties properties = channel.CreateBasicProperties();
properties.CorrelationId = correlationId; // correlationId'yi ekliyoruz.// Göndereceğimiz mesajın hangi kuyruğa gönderileceğini belirtiyoruz.
properties.ReplyTo = replyQueueName; // Response mesajının hangi kuyruğa gönderileceğini belirtiyoruz.

for (int i = 0;i<100; i++)
{
    byte[] messageBody = Encoding.UTF8.GetBytes($"Hello World {i}");
    channel.BasicPublish(
        exchange:string.Empty,
        routingKey:requestQueueName,
        body:messageBody,
        basicProperties:properties
        );
}
#endregion

#region Response Kuyruğu Dinleme
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
    queue:replyQueueName,
    autoAck:true,
    consumer:consumer
    );

consumer.Received += (sender, eventArgs) =>
{
    if (eventArgs.BasicProperties.CorrelationId == correlationId)
    {
        //..
        byte[] responseBytes = eventArgs.Body.ToArray();
        string response = Encoding.UTF8.GetString(responseBytes);
        Console.WriteLine($"Response: {response}");
    }
};



#endregion



Console.Read();