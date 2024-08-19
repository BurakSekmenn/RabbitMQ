using MassTransit;
using MassTransit.Shared.Messages;

string rabbitMQuri = "";


string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQuri);

});

ISendEndpoint sendEndpoint= await bus.GetSendEndpoint(new($"{rabbitMQuri}/{queueName}"));  // endpoint bellirledik 

Console.WriteLine("Gönderilecek Mesaj :");
string message = Console.ReadLine();

await sendEndpoint.Send< IMessage> (new ExampleMessage() { Text = message });

Console.Read();
