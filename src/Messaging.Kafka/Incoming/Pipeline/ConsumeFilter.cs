using Messaging.Incoming;
using Messaging.Pipeline;

namespace Messaging.Kafka.Incoming.Pipeline;

internal class ConsumeFilter(IncomingMessageRouter router) : IFilter<KafkaConsumeContext>
{
    public async Task InvokeAsync(KafkaConsumeContext context, RequestDelegate next)
    {
        var envelope = new IncomingMessageEnvelope(context.ConsumeResult.Message.Value)
            .WithHeaders(context.ConsumeResult.Message.Headers);

        await router
            .Route(envelope)
            .SendAsync(envelope);
    }
}
