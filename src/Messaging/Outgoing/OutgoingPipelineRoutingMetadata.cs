namespace Messaging.Outgoing;

internal class OutgoingPipelineRoutingMetadata(string? explicitDestination, IEnumerable<Type> messageTypes)
{
    private readonly List<Type> _messageTypes = messageTypes.ToList();

    public string? ExplicitDestination { get; } = explicitDestination;

    public IEnumerable<Type> MessageTypes => _messageTypes;
}
