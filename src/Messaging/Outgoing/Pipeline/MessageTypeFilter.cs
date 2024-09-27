using Messaging.Pipeline;

namespace Messaging.Outgoing.Pipeline;

internal class MessageTypeFilter(MessageTypeRegistry registry) : IFilter<OutgoingMessageEnvelope>
{
    public async Task InvokeAsync(OutgoingMessageEnvelope context, RequestDelegate next)
    {
        context.Headers[MessageHeaders.MessageType] = registry.Get(context.Message.GetType()).MessageTypeIdentifier;

        await next();
    }
}
