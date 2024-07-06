namespace Messaging;

internal class Envelope(string body, Type messageType)
{
    public string Body { get; } = body;

    public Type MessageType { get; } = messageType;
}
