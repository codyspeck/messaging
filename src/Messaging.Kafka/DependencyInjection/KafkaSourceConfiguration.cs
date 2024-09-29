namespace Messaging.Kafka.DependencyInjection;

public class KafkaSourceConfiguration
{
    internal KafkaSourceConfiguration(string topic)
    {
        Topic = topic;
    }
    
    internal string Topic { get; }

    internal Type? MessageType { get; private set; }

    public KafkaSourceConfiguration WithMessageType<TMessage>()
    {
        MessageType = typeof(TMessage);
        return this;
    }
}
