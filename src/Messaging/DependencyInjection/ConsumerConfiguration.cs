namespace Messaging.DependencyInjection;

public class ConsumerConfiguration
{
    internal ConsumerConfiguration(Type consumerType)
    {
        ConsumerType = consumerType;
    }

    internal Type ConsumerType { get; }

    internal List<Type> MessageTypes { get; } = [];

    public ConsumerConfiguration HandlesMessage<TMessage>()
    {
        MessageTypes.Add(typeof(TMessage));
        return this;
    }
}
