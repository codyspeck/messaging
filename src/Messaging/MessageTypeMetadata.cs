namespace Messaging;

internal class MessageTypeMetadata(string messageTypeIdentifier, Type messageType)
{
    public string MessageTypeIdentifier { get; } = messageTypeIdentifier;

    public Type MessageType { get; } = messageType;
}
