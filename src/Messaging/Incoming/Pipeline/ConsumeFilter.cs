using Messaging.Pipeline;

namespace Messaging.Incoming.Pipeline;

public class ConsumeFilter(IConsumer consumer) : IFilter<IncomingMessageEnvelope>
{
    public async Task InvokeAsync(IncomingMessageEnvelope context, RequestDelegate next)
    {
        await consumer.ConsumeAsync(context.Message!);
    }
}
