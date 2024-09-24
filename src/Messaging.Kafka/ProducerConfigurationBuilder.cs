namespace Messaging.Kafka;

public class ProducerConfigurationBuilder
{
    private readonly string _topic;
    private readonly List<Type> _messageTypes = [];
    
    internal ProducerConfigurationBuilder(string topic)
    {
        _topic = topic;
    }

    public ProducerConfigurationBuilder Handles<TMessage>()
    {
        _messageTypes.Add(typeof(TMessage));
        return this;
    }
}
