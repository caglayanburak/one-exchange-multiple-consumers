using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace OneQueueMultipleConsumerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<ISortStartedEventHandler, SortStartedConsumer>()
            .AddTransient<IPackagingSortStartedEventHandler, SortStartedForPackagingConsumer>()
            .BuildServiceProvider();



            //do the actual work here
            var sortStarted = serviceProvider.GetService(typeof(ISortStartedEventHandler));
            var sortStartedPacking = serviceProvider.GetService(typeof(IPackagingSortStartedEventHandler));

            Console.WriteLine("Masstransit consumers init");
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
           {
               var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
               {
                   h.Username("guest");
                   h.Password("guest");
               });

               cfg.ReceiveEndpoint(host, "trendyol_sort_started", e =>
               {
                   e.PrefetchCount = 1;
                   e.Consumer(typeof(SortStartedConsumer), type => sortStarted);
               });

               cfg.ReceiveEndpoint(host, "trendyol_packing_sort_started", e =>
               {
                   e.PrefetchCount = 1;
                   e.Consumer(typeof(SortStartedForPackagingConsumer), type => sortStartedPacking);
               });
           });

            busControl.Start();
            Console.ReadLine();
        }
    }
}
