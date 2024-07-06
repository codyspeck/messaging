namespace Messaging;

public interface IMessageBus
{
    Task SendAsync(object message);
}

internal class MessageBus : IMessageBus
{
    public Task SendAsync(object message)
    {
        throw new NotImplementedException();
    }
}
