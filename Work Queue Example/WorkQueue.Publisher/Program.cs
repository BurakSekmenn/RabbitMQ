using RabbitMQ.Client;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

string queueName = "example-work-queue";

channel.QueueDeclare(queue: queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false);

for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] body = Encoding.UTF8.GetBytes($"Message {i}");

    channel.BasicPublish(
     exchange: string.Empty,
     routingKey: queueName,
     body: body);

}



Console.Read();