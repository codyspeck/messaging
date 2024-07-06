namespace Messaging;

internal class Envelope(object message)
{
    public object Message { get; } = message;
}
