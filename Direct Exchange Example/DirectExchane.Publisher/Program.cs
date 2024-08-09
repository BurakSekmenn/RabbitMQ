using RabbitMQ.Client;
using System.Text;

//bağlantı oluşturma
ConnectionFactory factory = new();
factory.Uri = new("YouURl");

using IConnection connection = factory.CreateConnection(); 
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange:"direct-exchange-example",type:ExchangeType.Direct);
// ExcahngType bakacak rabbitmq Bizden Routing key bekleyecek
while (true)
{
    int number = 0;

    // Mesaj Göndereceğiniz kuyruğu seçiniz
    Console.Write("Mesaj kuyruğu 1: | Mesaj Kuyruğu içi 2 Basınız: ");
    number = Convert.ToInt32(Console.ReadLine());

    Console.Write("Mesaj: ");
    string message = Console.ReadLine();

    string exchange = number == 1 ? "direct-exchange-example" : "direct-exchange-example-two";
    string routingKey = number == 1 ? "direct-queue" : "direct-queue-two";

    while (true)
    {
        byte[] byteMessage = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: exchange,
            routingKey: routingKey,
            body: byteMessage
        );

        if (number == 1)
        {
            Console.WriteLine("Kuyruktan çıkmak için 1'e basın:");
            int exit = Convert.ToInt32(Console.ReadLine());
            if (exit == 1)
            {
                break;
            }
        }
    }

}





Console.Read();