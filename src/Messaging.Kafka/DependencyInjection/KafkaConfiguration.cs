namespace Messaging.Kafka.DependencyInjection;

public class KafkaConfiguration
{
    internal List<KafkaDestinationConfiguration> Destinations { get; } = [];
    
    internal List<KafkaSourceConfiguration> Sources { get; } = [];

    public KafkaConfiguration AddDestination(string topic, Action<KafkaDestinationConfiguration> configurator)
    {
        var destination = new KafkaDestinationConfiguration(topic);
        configurator(destination);
        Destinations.Add(destination);
        return this;
    }

    public KafkaConfiguration AddSource(string topic, Action<KafkaSourceConfiguration> configurator)
    {
        var source = new KafkaSourceConfiguration(topic);
        configurator(source);
        Sources.Add(source);
        return this;
    }
}
