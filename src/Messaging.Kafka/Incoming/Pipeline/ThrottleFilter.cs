using System.Threading.Tasks.Dataflow;
using Messaging.Pipeline;

namespace Messaging.Kafka.Incoming.Pipeline;

using Yeet = (RequestDelegate Next, TaskCompletionSource Source);

internal class ThrottleFilter : IFilter<KafkaConsumeContext>
{
    private readonly ActionBlock<Yeet> _block = new(
        async yeet =>
        {
            try
            {
                await yeet.Next();
                yeet.Source.TrySetResult();
            }
            catch (Exception exception)
            {
                yeet.Source.TrySetException(exception);
            }
        });
    
    public async Task InvokeAsync(KafkaConsumeContext context, RequestDelegate next)
    {
        var source = new TaskCompletionSource();
        
        await _block.SendAsync((next, source));

        await source.Task;
    }
}
