using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

ConnectionFactory factory = new();
factory.Uri = new("YouURl");


using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();
int number = 0;
Console.Write("Dinlemek İstediğiniz Kuyruk 1: | \"Dinlemek İstediğiniz Kuyruk  2 Basınız :");
number = Convert.ToInt32(Console.ReadLine());
if (number==1)
{
    // 1.Adım
    channel.ExchangeDeclare(
        exchange: "direct-exchange-example",
        type: ExchangeType.Direct);
    //2. Adım
    string queueNanme = channel.QueueDeclare().QueueName;// kuyruğun adını alıyoruz

    //3. Adım
    channel.QueueBind(
        queue: queueNanme,
        exchange: "direct-exchange-example",
        routingKey: "direct-queue");

    EventingBasicConsumer consumer = new(channel);
    channel.BasicConsume(queue: queueNanme, autoAck: true, consumer: consumer);
    consumer.Received += (sender, e) =>
    {
        string message = Encoding.UTF8.GetString(e.Body.Span);
        Console.WriteLine(message);
    };
}
else
{
    channel.ExchangeDeclare(
        exchange: "direct-exchange-example-two",
        type:ExchangeType.Direct);
    string queName = channel.QueueDeclare().QueueName;

    channel.QueueBind(
        queue:queName,
        exchange: "direct-exchange-example-two",
        routingKey: "direct-queue-two");
    EventingBasicConsumer consumer = new(channel);
    channel.BasicConsume(queue: queName,autoAck:true,consumer:consumer);
    consumer.Received += (sender,e) =>
    {
        string message = Encoding.UTF8.GetString(e.Body.Span);
        Console.WriteLine(message);
    };
}



Console.Read();

//1.Adım : Publisher'daki exchange ile birebir aynı isim ve type'a sahip bir exchange tanımlanmalıdır.!
//2. Adım : Publisher tarafından routin Keyde' bulunan değerdeki kuyruğa gönderilen mesajları kendi oluşturduğumuz kuyruğa yönlendirerek tüketmemiz gerekmektedir. Bunu için öncelikle bir kuyruk oluşturulmalıdır.
