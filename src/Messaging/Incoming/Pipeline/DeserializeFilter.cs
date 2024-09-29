using Messaging.Pipeline;

namespace Messaging.Incoming.Pipeline;

internal class DeserializeFilter(IMessageSerializer serializer, MessageTypeRegistry registry)
    : IPipe<IncomingMessageEnvelope>
{
    public Task SendAsync(IncomingMessageEnvelope context)
    {
        var messageType = context.ExplicitMessageType ?? registry.Get(context.Headers[MessageHeaders.MessageType]!).MessageType;

        context.Message = serializer.Deserialize(context.MessageSerialized!, messageType);

        return Task.CompletedTask;
    }
}