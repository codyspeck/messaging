namespace Messaging.Outgoing;

internal class MessageSenderRoutingOptions(string? explicitDestination, IEnumerable<Type> messageTypes)
{
    public string? ExplicitDestination { get; } = explicitDestination;

    public List<Type> MessageTypes { get; } = messageTypes.ToList();
}
