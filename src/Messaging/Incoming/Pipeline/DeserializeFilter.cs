using Messaging.Pipeline;

namespace Messaging.Incoming.Pipeline;

internal class DeserializeFilter(IMessageSerializer serializer, MessageTypeRegistry registry)
    : IFilter<IncomingMessageEnvelope>
{
    public async Task InvokeAsync(IncomingMessageEnvelope context, RequestDelegate next)
    {
        var messageType = context.ExplicitMessageType ?? registry.Get(context.Headers[MessageHeaders.MessageType]!).MessageType;

        context.Message = serializer.Deserialize(context.SerializedMessage, messageType);

        await next();
    }
}