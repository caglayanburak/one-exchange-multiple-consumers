using System;
using System.Threading.Tasks;
using MassTransit;

namespace OneQueueMultipleConsumerSample
{
    public class SortStartedForPackagingConsumer : IConsumer<SortStarted>, IPackagingSortStartedEventHandler
    {
        public async Task Consume(ConsumeContext<SortStarted> context)
        {
            var message = context.Message;

            Console.Out.WriteLine($"Sort started for sortstartedforpackagingconsumer jobId:{message.JobId}");
        }
    }
}