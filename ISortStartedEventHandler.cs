using System.Threading.Tasks;
using MassTransit;

namespace OneQueueMultipleConsumerSample
{
    public interface ISortStartedEventHandler
    {
        Task Consume(ConsumeContext<SortStarted> context);
    }
}