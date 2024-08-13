// routing key'leri kullanarak mesajları kuyruklara yönlendirmek için kullanılan bir exchange türüdür.Bu exchange ile routing key'in bir ksımına/formatına/yapısına keylere göre kuyruklara mesaj gönderiliri.
// kuyruklar da routing key'e göre ebu exchange'e abone olabilirler ve sadece ilgil routing key'e göre gönderilen mesajları alabilirler.


using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouURl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
    exchange: "topic-exchange-example",
    type: ExchangeType.Topic);

Console.WriteLine("Dinlenecek Topic Formatını Belirtiniz:");
string topic = Console.ReadLine();


string quename = channel.QueueDeclare().QueueName; // Query ismi aldım 
channel.QueueBind(queue:quename,
    exchange: "topic-exchange-example",
    routingKey:topic);


EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
    
    queue:quename,
    autoAck:true,
    consumer);

consumer.Received += (sender, e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);
};

Console.Read();