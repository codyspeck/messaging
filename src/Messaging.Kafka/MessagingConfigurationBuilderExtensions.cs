namespace Messaging.Kafka;

public static class MessagingConfigurationBuilderExtensions
{
    public static MessagingConfiguration AddKafka(
        this MessagingConfiguration messagingConfiguration,
        Action<KafkaConfigurationBuilder> configurator)
    {
        var kafkaConfigurationBuilder = new KafkaConfigurationBuilder();
        configurator(kafkaConfigurationBuilder);
        return messagingConfiguration;
    }
}
