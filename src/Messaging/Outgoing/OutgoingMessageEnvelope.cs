namespace Messaging.Outgoing;

public class OutgoingMessageEnvelope(object message)
{
    public object Message { get; } = message;

    internal Dictionary<string, string> Headers { get; } = [];

    internal TaskCompletionSource TaskCompletionSource { get; } = new();
}
