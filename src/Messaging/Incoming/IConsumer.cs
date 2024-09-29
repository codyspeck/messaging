namespace Messaging.Incoming;

public interface IConsumer
{
    Task ConsumeAsync(object message);
}
