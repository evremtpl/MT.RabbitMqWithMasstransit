using MassTransit;
using MT.RabbitMq;
using System;

namespace MT.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Order Service";

            var bus = BusConfigurator.Instance.ConfigureBus((cfg,host) =>
            {
                cfg.ReceiveEndpoint(MqConstants.OrderQueue, e =>
                {
                    e.Consumer<OrderCommandConsumer>();


                });


            });
            bus.Start();
            Console.WriteLine("Listening Order Command");
            Console.ReadLine();
        }
    }
}
