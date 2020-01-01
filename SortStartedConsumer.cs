using System;
using System.Threading.Tasks;
using MassTransit;

namespace OneQueueMultipleConsumerSample
{
    class SortStartedConsumer : IConsumer<SortStarted>, ISortStartedEventHandler
    {
        public async Task Consume(ConsumeContext<SortStarted> context)
        {
            var message = context.Message;

            Console.Out.WriteLine($"Sort started for sortstartedconsumer jobId:{message.JobId}");
        }
    }
}