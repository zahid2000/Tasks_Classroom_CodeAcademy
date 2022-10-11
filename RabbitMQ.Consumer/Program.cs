using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

const string queue_name = "code-queue";

var factory = new ConnectionFactory
{
    HostName = "localhost",
    Uri=new Uri("amqp://guest:guest@localhost:5672")
};

using var connection = factory.CreateConnection();
using var channel=connection.CreateModel();
channel.QueueDeclare(queue_name,durable:true,exclusive:false,autoDelete:false,arguments:null);


var consumer=new EventingBasicConsumer(channel);
consumer.Received += Consumer_Received;

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body=e.Body.ToArray();
    var message=Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
    Thread.Sleep(1500);
}

channel.BasicConsume(queue_name, true, consumer);
Console.WriteLine("Consume Started");

Console.ReadKey();