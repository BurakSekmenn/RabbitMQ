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

Console.WriteLine("Lütfen Header Valu'sunu Giriniz : ");
string value = Console.ReadLine();

string queueName=channel.QueueDeclare().QueueName;

channel.QueueBind(
    queue: queueName,
    exchange: "header-exchange",
    routingKey: string.Empty,
    arguments: new Dictionary<string, object>
    {
        ["x-match"] = "all",
        ["no"] = value,
        ["For Degeri"] = 1
    }
    );
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

consumer.Received += (object sender, BasicDeliverEventArgs e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);
};



Console.Read();