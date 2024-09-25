namespace Messaging.Kafka;

public class ProducerConfigurationBuilder
{
    private readonly string _topic;
    private readonly HashSet<Type> _messageTypes = [];
    
    internal ProducerConfigurationBuilder(string topic)
    {
        _topic = topic;
    }

    public ProducerConfigurationBuilder Handles<TMessage>()
    {
        _messageTypes.Add(typeof(TMessage));
        return this;
    }

    internal ProducerConfiguration Build() => new(_topic, _messageTypes);
}

internal class ProducerConfiguration(string topic, HashSet<Type> messageTypes)
{
    public string Topic { get; } = topic;

    public HashSet<Type> MessageTypes { get; } = messageTypes;
}
