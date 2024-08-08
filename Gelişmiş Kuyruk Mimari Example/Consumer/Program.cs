//Gelişmiş Kuyruk Mimarisi ,Message Acknowledgement,BasicNack,Message Durability,Fair Dispatching  Örnekleri

//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Text;
//// Message Acknowledgemen Örneği


//ConnectionFactory factory = new();
//factory.Uri = new("YouURl");

//// Bağlantı Aktifleştirme ve Kanal Açma
//using IConnection connection = factory.CreateConnection();
//using IModel channel = connection.CreateModel();

//channel.QueueDeclare(queue: "example-queue", exclusive: false);
//// Message Acknowledgement işlemi için bir consumer oluşturuyoruz. 

//// Önemli Bir Nottttt
//// Message Acknowledgement işlemi işlem bitince rabbitmq bildiri gönderiyoruz ki veri kaybı yaşamasın diye 

//EventingBasicConsumer consumer = new(channel);
//channel.BasicConsume(queue: "example-queue", autoAck: false, consumer);
//// autoAck consumer'ın mesajı aldıktan sonra kuyruktan silinip silinmeyeceğini belirler. true olursa mesajı aldıktan sonra kuyruktan silinir. false olursa mesajı aldıktan sonra kuyruktan silinmez ve mesajın işlendiğini belirtmek için bir ack mesajı gönderilmesi gerekir.
//consumer.Received += (sender, e) =>
//{
//    // Kuyruğa gelen mesajın işlendiği yerdir!
//    /* e.Body*/ // Kuyruktai mesajın verisini bütünsel olarak getirecektir byte[] türünde mesajı alır
//    /*e.Body.Span; */// byte[] türündeki mesajı span türüne çevirir
//    //e.Body.ToArray(); // byte[] türündeki mesajı byte[] türüne çevirir
//    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
//    // Kuyruktan mesajı silme talimatı vereceğiz.
//    channel.BasicAck(e.DeliveryTag, multiple: false);
//    //multiple: false tek bir mesajın silinmesi için kullanılır. true olursa belirtilen mesajdan önceki tüm mesajlar silinir.
//};

//Console.Read();

// Messae Durability Örneği 

//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Text;
//// Message Acknowledgemen Örneği


//ConnectionFactory factory = new();
//factory.Uri = new("YouURl");

//// Bağlantı Aktifleştirme ve Kanal Açma
//using IConnection connection = factory.CreateConnection();
//using IModel channel = connection.CreateModel();

//channel.QueueDeclare(queue: "example-queue", exclusive: false,durable:true) ;// publisherda durable:true yaptıysan burada belirlemen gerekiyor.


//EventingBasicConsumer consumer = new(channel);
//channel.BasicConsume(queue: "example-queue", autoAck: false, consumer) ;

//consumer.Received += (sender, e) =>
//{

//    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));

//    channel.BasicAck(e.DeliveryTag, multiple: false);

//};

//Console.Read();





//Fair Dispatch Örneği Adil Dağıtım

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;



ConnectionFactory factory = new();
factory.Uri = new("YouURl");

// Bağlantı Aktifleştirme ve Kanal Açma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.QueueDeclare(queue: "example-queue", exclusive: false, durable: true);// publisherda durable:true yaptıysan burada belirlemen gerekiyor.


EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue", autoAck: false, consumer);
channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false); // prefetchSize: 0, prefetchCount: 1, global: false -> bu ayarlar ile consumer'a sadece bir mesaj gönderilir ve mesaj işlendikten sonra bir diğer mesaj gönderilir. Bu sayede mesajlar adil bir şekilde dağıtılır.

consumer.Received += (sender, e) =>
{

    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));

    channel.BasicAck(e.DeliveryTag, multiple: false);

};

Console.Read();

