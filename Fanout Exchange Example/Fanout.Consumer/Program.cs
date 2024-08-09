// Fanout Exchange -> Mesajların, bu exchange'e bind olmuş olan tüm kuyruklara gönderilmesini sağlar. Publisher mesajların gönderildiği kuyruk isimlere dikkate almaz ve mesajlara tüm kuyruklara gönderir

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouURl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
    exchange: "fanout-exchange-example",
    type:ExchangeType.Fanout
    );

Console.WriteLine("Kuyruk Adını Giriniz:");
string queueName = Console.ReadLine();

channel.QueueDeclare(queue:queueName,
    exclusive:false);

channel.QueueBind(
    queue:queueName,
    exchange: "fanout-exchange-example",
    routingKey:string.Empty
    );

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue:queueName,
    autoAck:true,consumer:consumer);

consumer.Received += (sender, e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);
};



Console.Read();