// Point to Point Tasarımı (P2P) Örneği Publisher Uygulaması

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouUrl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

string queueName = "p2p-example";

channel.QueueDeclare(
    queue:queueName,
    durable:false,
    autoDelete:false);

byte[] message = Encoding.UTF8.GetBytes("Merhaba!");
channel.BasicPublish(
    exchange:string.Empty,
    routingKey:queueName,
    body:message);


Console.Read();