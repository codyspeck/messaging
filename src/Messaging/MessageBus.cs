namespace Messaging;

public interface IMessageBus
{
    Task SendAsync(object message);
}

internal class MessageBus(IEnveloper enveloper, IEnumerable<ITransport> transports) : IMessageBus
{
    public async Task SendAsync(object message)
    {
        var envelope = enveloper.Envelope(message);

        await transports
            .Select(transport => transport.SendAsync(envelope))
            .WhenAll();
    }
}
