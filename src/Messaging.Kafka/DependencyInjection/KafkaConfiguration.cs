using Confluent.Kafka;

namespace Messaging.Kafka.DependencyInjection;

public class KafkaConfiguration
{
    internal List<KafkaDestinationConfiguration> Destinations { get; } = [];
    internal List<KafkaSourceConfiguration> Sources { get; } = [];

    public KafkaConfiguration Destination(string topic, Action<KafkaDestinationConfiguration> configurator)
    {
        var destination = new KafkaDestinationConfiguration(topic);

        configurator(destination);
        
        Destinations.Add(destination);

        return this;
    }

    public KafkaConfiguration Source(string topic, Action<KafkaSourceConfiguration> configurator)
    {
        var source = new KafkaSourceConfiguration(topic);

        configurator(source);

        Sources.Add(source);

        return this;
    }

    public ClientConfig BuildClientConfig()
    {
        return new ClientConfig { BootstrapServers = "localhost:9092" };
    }
}
