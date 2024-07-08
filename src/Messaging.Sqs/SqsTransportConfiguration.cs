namespace Messaging.Sqs;

public class SqsTransportConfiguration
{
    private readonly ICollection<SqsProducerConfiguration> _producerConfigurations = [];

    internal IEnumerable<SqsProducerConfiguration> ProducerConfigurations => _producerConfigurations;
    
    internal SqsTransportConfiguration()
    {
    }
    
    public SqsTransportConfiguration ProduceToSqsQueue(string queue, Action<SqsProducerConfiguration> configurator)
    {
        var sqsProducerConfiguration = new SqsProducerConfiguration(queue);

        configurator(sqsProducerConfiguration);

        _producerConfigurations.Add(sqsProducerConfiguration);
        
        return this;
    }
}
