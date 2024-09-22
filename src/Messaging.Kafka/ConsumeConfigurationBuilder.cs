namespace Messaging.Kafka;

public class ConsumeConfigurationBuilder
{
    private readonly List<string> _topics = [];

    internal ConsumeConfigurationBuilder()
    {
    }

    public ConsumeConfigurationBuilder WithTopic(string topic)
    {
        _topics.Add(topic);
        return this;
    }
}
