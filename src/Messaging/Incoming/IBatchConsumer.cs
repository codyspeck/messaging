namespace Messaging.Incoming;

public interface IBatchConsumer
{
    Task ConsumeAsync(IEnumerable<object> messages);
}
