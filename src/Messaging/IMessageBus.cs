namespace Messaging;

public interface IMessageBus
{
    Task SendAsync(object message);
}
