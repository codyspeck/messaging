namespace Messaging.Sqs;

public static class MessagingConfigurationExtensions
{
    public static MessagingConfiguration AddSqs(this MessagingConfiguration messagingConfiguration,
        Action<SqsTransportConfiguration> configurator)
    {
        return messagingConfiguration;
    }
    
    // public static MessagingConfiguration ProduceToSqsQueue(this MessagingConfiguration messagingConfiguration,
    //     string queue,
    //     Action<SqsProducerConfiguration> configurator)
    // {
    //     var sqsProducerConfiguration = new SqsProducerConfiguration(queue);
    //     
    //     configurator(sqsProducerConfiguration);
    //     
    //     messagingConfiguration.AddEndpointConfiguration(sqsProducerConfiguration);
    //     
    //     return messagingConfiguration;
    // } 
}
