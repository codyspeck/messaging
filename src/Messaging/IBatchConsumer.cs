namespace Messaging;

public interface IBatchConsumer
{
    Task ConsumeAsync(IEnumerable<(object, object)> messages);
}

public interface IBatchConsumer<TMessage> : IBatchConsumer
{
    Task ConsumeAsync(IEnumerable<(TMessage, object)> messages);

    Task IBatchConsumer.ConsumeAsync(IEnumerable<(object, object)> messages)
    {
        return ConsumeAsync(messages.Select(message => ((TMessage)message.Item1, message.Item2)));
    }
}
