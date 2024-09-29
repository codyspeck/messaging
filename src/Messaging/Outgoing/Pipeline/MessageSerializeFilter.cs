using Messaging.Pipeline;

namespace Messaging.Outgoing.Pipeline;

internal class MessageSerializeFilter(IMessageSerializer serializer) : IFilter<OutgoingMessageEnvelope>
{
    public async Task InvokeAsync(OutgoingMessageEnvelope context, RequestDelegate next)
    {
        context.MessageSerialized = serializer.Serialize(context.Message);

        await next();
    }
}
