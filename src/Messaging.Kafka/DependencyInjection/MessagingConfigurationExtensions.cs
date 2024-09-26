using Messaging.DependencyInjection;

namespace Messaging.Kafka.DependencyInjection;

public static class MessagingConfigurationExtensions
{
    public static MessagingConfiguration AddKafka(
        this MessagingConfiguration messagingConfiguration,
        Action<KafkaConfiguration> configurator)
    {
        var kafkaConfiguration = new KafkaConfiguration();

        configurator(kafkaConfiguration);
        
        messagingConfiguration.Transports.Add(new KafkaTransport(kafkaConfiguration));

        return messagingConfiguration;
    }    
}
