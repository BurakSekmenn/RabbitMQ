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
    type:ExchangeType.Fanout);

for (int i = 0; i < 100; i++)
{
    byte[] message = Encoding.UTF8.GetBytes("Merhaba "+ i);
    channel.BasicPublish(
    exchange: exchangeName,
    routingKey: string.Empty,
    body: message
    );
}






Console.Read();