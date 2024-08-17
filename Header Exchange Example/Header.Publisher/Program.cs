// Routing key yerine header'ları kullanarak mesajları kuyruklara yönelendirmek için kullanılan exchange'dir.

// x-match : iligli queue'nun mesajı hangi davranisla lacağını kararini veren bir keydir.
// all : tüm header'lar eşleşmeli
// any : en az bir header eşleşmeli
// none : hiç bir header eşleşmemeli

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouURl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
    exchange:"header-exchange", 
    type: ExchangeType.Headers);

for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes($"Merhaba {i}");
    Console.WriteLine("Lütfen Header Value'sunu Giriniz:");
    string value = Console.ReadLine();

    IBasicProperties basicProperties= channel.CreateBasicProperties();
    basicProperties.Headers = new Dictionary<string, object>
    {
        ["no"] = value,
        ["For Degeri"] = i
    };

    channel.BasicPublish(
        exchange: "header-exchange",
        routingKey: string.Empty,
        body:message,
        basicProperties: basicProperties
        );
}



Console.Read();

