////Gelişmiş Kuyruk Mimarisi ,Message Acknowledgement,BasicNack,Message Durability,Fair Dispatching  Örnekleri

//using RabbitMQ.Client;
//using System.Text;

////Round Robin algoritması ile mesajları consumer'lara dağıtır.


////bağlantı oluşturma
//ConnectionFactory connectionFactory = new();
//connectionFactory.Uri = new("YouURl");

//// Bağlantıyı Aktifleştirme ve Kanal Açma
//using IConnection connection = connectionFactory.CreateConnection(); // dispose edilmesi gerekiyor
//using IModel channel = connection.CreateModel();

//// Queue Oluşturma
//channel.QueueDeclare(queue: "example-queue", exclusive: false);// exclusive: false olursa birden fazla consumer aynı queue'yu kullanabilir
//// Queue'ya mesaj gönderme
//// RabbitMQ kuyruğa atacağı mesajları byte türünden kabul etmektedir. Bu nedenle mesajı byte türüne çevirmemiz gerekmektedir.
////byte[] message = Encoding.UTF8.GetBytes("Merhaba RabbitMQ");
////channel.BasicPublish(exchange:"",routingKey: "example-queue",body:message);

//for (int i = 0; i < 100; i++)
//{
//    Task.Delay(200).Wait();
//    byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
//    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);

//}

//Console.Read();


// Messae Durability Örneği 

//using RabbitMQ.Client;
//using System.Text;



////bağlantı oluşturma
//ConnectionFactory connectionFactory = new();
//connectionFactory.Uri = new("YouURl");

//// Bağlantıyı Aktifleştirme ve Kanal Açma
//using IConnection connection = connectionFactory.CreateConnection();
//using IModel channel = connection.CreateModel();


//channel.QueueDeclare(queue: "example-queue", exclusive: false, durable:true) ;// exclusive: false olursa birden fazla consumer aynı queue'yu kullanabilir. // durable:true -> mesajların kalıcı olmasını sağlar

//IBasicProperties properties = channel.CreateBasicProperties();
//properties.Persistent = true; // mesajların kalıcı olmasını sağlar

//for (int i = 0; i < 100; i++)
//{
//    Task.Delay(200).Wait();
//    byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
//    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message ,basicProperties:properties); // publish edeceğim mesajlarıda yapmamz gerekiyor 

//}

//Console.Read();


using RabbitMQ.Client;
using System.Text;



//bağlantı oluşturma
ConnectionFactory connectionFactory = new();
connectionFactory.Uri = new("YouURl");

// Bağlantıyı Aktifleştirme ve Kanal Açma
using IConnection connection = connectionFactory.CreateConnection();
using IModel channel = connection.CreateModel();


channel.QueueDeclare(queue: "example-queue", exclusive: false, durable: true);

IBasicProperties properties = channel.CreateBasicProperties();
properties.Persistent = true; // mesajların kalıcı olmasını sağlar

for (int i = 0; i < 100; i++)
{
    Task.Delay(200).Wait();
    byte[] message = Encoding.UTF8.GetBytes("Beslenen Consumer " + i + " Merhaba " + i);
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message, basicProperties: properties); // publish edeceğim mesajlarıda yapmamz gerekiyor 

}

Console.Read();

