//// Fanout Exchange -> Mesajların, bu exchange'e bind olmuş olan tüm kuyruklara gönderilmesini sağlar. Publisher mesajların gönderildiği kuyruk isimlere dikkate almaz ve mesajlara tüm kuyruklara gönderir
///
using RabbitMQ.Client;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouURl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange:"fanout-exchange-example",
    type:ExchangeType.Fanout);

for (int i = 1; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes($"Merhaba {i}");
    channel.BasicPublish(
        exchange: "fanout-exchange-example",
        routingKey:string.Empty,
        body:message
        );// Fanout rotuing key boş olmalı çünkü fıtratı gereği böyle
}


Console.Read();

