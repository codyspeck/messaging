namespace Messaging.Kafka;

public static class MessagingConfigurationBuilderExtensions
{
    public static MessagingConfigurationBuilder AddKafka(
        this MessagingConfigurationBuilder messagingConfigurationBuilder,
        Action<KafkaConfigurationBuilder> configurator)
    {
        var kafkaConfigurationBuilder = new KafkaConfigurationBuilder();

        configurator(kafkaConfigurationBuilder);
        
        return messagingConfigurationBuilder;
    }
}
