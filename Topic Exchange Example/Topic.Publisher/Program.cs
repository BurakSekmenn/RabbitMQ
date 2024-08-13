//// routing key'leri kullanarak mesajları kuyruklara yönlendirmek için kullanılan bir exchange türüdür.Bu exchange ile routing key'in bir ksımına/formatına/yapısına keylere göre kuyruklara mesaj gönderiliri.
// kuyruklar da routing key'e göre ebu exchange'e abone olabilirler ve sadece ilgil routing key'e göre gönderilen mesajları alabilirler.

using RabbitMQ.Client;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouURl");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
    exchange:"topic-exchange-example",
    type:ExchangeType.Topic);
for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes($"Message {i}");
    Console.WriteLine("Mesjaın Gönderilecek Topic Formatını Belirtiniz : ");
    string topic = Console.ReadLine();
    channel.BasicPublish(
               exchange: "topic-exchange-example",
                      routingKey: topic,
                                    body: message);
}

Console.Read();


// Rabbit Toxic Gödnderirken
// # => 0 veya daha fazla kelimeyi temsil eder.
// * => 1 kelimeyi temsil eder.
// https://www.gencayyildiz.com/blog/rabbitmq-topic-exchange/ tam içerği burada var.
// routing key'leri kullanarak mesajları kuyruklara yönlendirmek için kullanılan bir exchange türüdür.Bu exchange ile routing key'in bir ksımına/formatına/yapısına keylere göre kuyruklara mesaj gönderiliri.