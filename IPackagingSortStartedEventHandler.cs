using System.Threading.Tasks;
using MassTransit;

namespace OneQueueMultipleConsumerSample
{
    public interface IPackagingSortStartedEventHandler
    {
         Task Consume(ConsumeContext<SortStarted> context);
    }
}