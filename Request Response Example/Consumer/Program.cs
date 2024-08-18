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

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
            queue: requestQueueName,
            autoAck: true,
            consumer: consumer);

consumer.Received += (sender, eventArgs) =>
{
    string message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
    Console.WriteLine(message);
    //.. işlemleri yaptın vs
    byte[] responseMessage = Encoding.UTF8.GetBytes("İşlem Tamamlandı :" + message);
    IBasicProperties properties = channel.CreateBasicProperties();
    properties.CorrelationId = eventArgs.BasicProperties.CorrelationId;// correlationId'yi ekliyoruz.// Göndereceğimiz mesajın hangi kuyruğa gönderileceğini belirtiyoruz.
    channel.BasicPublish(
        exchange: string.Empty,
        routingKey: eventArgs.BasicProperties.ReplyTo,// response mesajının hangi kuyruğa gönderileceğini belirtiyoruz.
        basicProperties: properties,
        body: responseMessage
        );
};


Console.Read();


