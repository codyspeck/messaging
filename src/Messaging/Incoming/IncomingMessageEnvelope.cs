namespace Messaging.Incoming;

public class IncomingMessageEnvelope(object message)
{
    public object Message { get; } = message;
}
