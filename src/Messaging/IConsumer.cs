namespace Messaging;

public interface IConsumer
{
    Task ConsumeAsync(Yeet message);
}

public interface IConsumer<in TMessage> : IConsumer
{
    Task ConsumeAsync(TMessage message);

    Task IConsumer.ConsumeAsync(object message)
    {
        return ConsumeAsync(message);
    }
}
