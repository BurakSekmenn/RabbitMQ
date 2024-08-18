//// Point to Point Tasarımı (P2P) Örneği Consumer Uygulaması

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
    queue: queueName,
    durable: false,
    autoDelete: false);

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
    queue:queueName,
    autoAck:false,
    consumer:consumer);

consumer.Received += (sender, eventArgs) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(eventArgs.Body.Span));
};

Console.ReadLine();

