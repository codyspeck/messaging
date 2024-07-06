namespace Messaging;

public interface IMessageBus
{
    Task SendAsync(object message);
}

internal class MessageBus(IEnumerable<ITransport> transports) : IMessageBus
{
    public async Task SendAsync(object message)
    {
        await Task.WhenAll(
            transports.Select(transport => transport.SendAsync(message)));
    }
}
