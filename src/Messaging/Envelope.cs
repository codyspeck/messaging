namespace Messaging;

internal class Envelope(string messageBody, string? explicitDestination, Type messageType)
{
    public string MessageBody { get; } = messageBody;

    public string? ExplicitDestination { get; } = explicitDestination;

    public Type MessageType { get; } = messageType;
}
