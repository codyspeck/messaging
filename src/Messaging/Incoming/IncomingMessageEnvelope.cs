namespace Messaging.Incoming;

public class IncomingMessageEnvelope(string serializedMessage)
{
    public object? Message { get; set; }

    public string SerializedMessage { get; } = serializedMessage;

    public Type? ExplicitMessageType { get; set; }

    public Dictionary<string, string?> Headers { get; } = [];

    public TaskCompletionSource TaskCompletionSource { get; } = new();
}
