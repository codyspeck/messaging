namespace Messaging.Outgoing;

public class OutgoingMessageEnvelope(object message)
{
    public object Message { get; } = message;

    internal string? ExplicitDestination { get; private set; }

    internal Dictionary<string, string?> Headers { get; } = [];

    internal TaskCompletionSource TaskCompletionSource { get; } = new();

    public OutgoingMessageEnvelope WithExplicitDestination(string explicitDestination)
    {
        ExplicitDestination = explicitDestination;
        return this;
    }
}
