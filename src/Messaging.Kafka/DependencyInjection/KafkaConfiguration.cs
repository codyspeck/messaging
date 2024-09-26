using Confluent.Kafka;

namespace Messaging.Kafka.DependencyInjection;

public class KafkaConfiguration
{
    internal List<KafkaDestinationConfiguration> Destinations { get; } = [];

    public KafkaConfiguration Destination(string topic, Action<KafkaDestinationConfiguration> configurator)
    {
        var destination = new KafkaDestinationConfiguration(topic);

        configurator(destination);
        
        Destinations.Add(destination);

        return this;
    }

    public ClientConfig BuildClientConfig()
    {
        return new ClientConfig();
    }
}
