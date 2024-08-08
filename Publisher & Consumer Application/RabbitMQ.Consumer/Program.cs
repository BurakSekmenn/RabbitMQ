// Bağlantı Oluşturma
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("YouURl");

// Bağlantı Aktifleştirme ve Kanal Açma
using IConnection connection = factory.CreateConnection(); // dispose edilmesi gerekiyor
using IModel channel = connection.CreateModel();
// Queue Oluşturma
channel.QueueDeclare(queue: "example-queue", exclusive: false); // exclusive: false olursa birden fazla consumer aynı queue'yu kullanabilir
// Consumer'da kuyruk publisherdaki ile birebir aynı yapılandırmada tanımlanmalıdır.


// Queue'dan Mesaj Okuma
// Consumer'ın kuyruktan mesaj okuyabilmesi için bir event oluşturulmalıdır.
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue", autoAck: false, consumer);
consumer.Received += (sender, e) =>
{
    // Kuyruğa gelen mesajın işlendiği yerdir!
    /* e.Body*/ // Kuyruktai mesajın verisini bütünsel olarak getirecektir byte[] türünde mesajı alır
    /*e.Body.Span; */// byte[] türündeki mesajı span türüne çevirir
    //e.Body.ToArray(); // byte[] türündeki mesajı byte[] türüne çevirir
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};

Console.Read();