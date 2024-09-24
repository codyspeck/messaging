namespace Messaging.Kafka;

public class KafkaConfigurationBuilder
{
    internal KafkaConfigurationBuilder()
    {
    }

    public KafkaConfigurationBuilder ConsumeFrom(Action<ListenerConfigurationBuilder> configurator)
    {
        var builder = new ListenerConfigurationBuilder();
        configurator(builder);
        return this;
    }

    public KafkaConfigurationBuilder ProduceTo(string topic, Action<ProducerConfigurationBuilder> configurator)
    {
        var builder = new ProducerConfigurationBuilder(topic);
        configurator(builder);
        return this;
    }
}
