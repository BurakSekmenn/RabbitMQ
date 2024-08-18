using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouUrl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();


string exchangeName = "example-pub-sub-exchange";
channel.ExchangeDeclare(
    exchange: exchangeName,
    type: ExchangeType.Fanout);

string queuname = channel.QueueDeclare().QueueName;

channel.QueueBind(
    queue:queuname,
    exchange :exchangeName,
    routingKey:string.Empty
    );

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
    queue:queuname,
    autoAck:false,
    consumer:consumer
    );

consumer.Received += (sender, e) =>
{
    byte[] body = e.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Gelen Mesaj: {message}");
};

Console.Read();