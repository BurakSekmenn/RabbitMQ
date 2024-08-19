using MassTransit;
using MassTransit.Consumer.Consumers;

string rabbitMQuri = "";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQuri);
    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });// bu endpoitie gelen mesejları receive eder
});

bus.Start();

Console.Read();

