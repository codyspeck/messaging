namespace Messaging.Sqs;

public class SqsTransportConfiguration
{
    internal SqsTransportConfiguration()
    {
    }

    public SqsTransportConfiguration ProduceToSqsQueue(string queue, Action<SqsProducerConfiguration> configurator)
    {
        var sqsProducerConfiguration = new SqsProducerConfiguration(queue);

        configurator(sqsProducerConfiguration);

        return this;
    }
}
