namespace Messaging.Incoming;

internal class IncomingMessagePipeRoutingMetadata(IEnumerable<Type> messageTypes)
{
    public List<Type> MessageTypes { get; } = messageTypes.ToList();
}
