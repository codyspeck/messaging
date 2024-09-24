namespace Messaging.Kafka;

public class ListenerConfigurationBuilder
{
    private readonly List<string> _topics = [];
    private Type? _foreignMessageType;

    internal ListenerConfigurationBuilder()
    {
    }

    public ListenerConfigurationBuilder CastMessagesTo<TMessage>()
    {
        _foreignMessageType = typeof(TMessage);
        return this;
    }
    
    public ListenerConfigurationBuilder Topic(string topic)
    {
        _topics.Add(topic);
        return this;
    }
}
