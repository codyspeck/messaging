namespace Messaging.Incoming;

public class IncomingMessageEnvelope
{
    public object? Message { get; set; }

    public string? MessageSerialized { get; set; }

    public Type? ExplicitMessageType { get; set; }

    public Dictionary<string, string?> Headers { get; } = new();

    public TaskCompletionSource TaskCompletionSource { get; } = new();
}
