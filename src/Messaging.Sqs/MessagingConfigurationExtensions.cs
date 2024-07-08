using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Sqs;

public static class MessagingConfigurationExtensions
{
    public static MessagingConfiguration AddSqsTransport(this MessagingConfiguration messagingConfiguration,
        Action<SqsTransportConfiguration> configurator)
    {
        var sqsTransportConfiguration = new SqsTransportConfiguration();

        configurator(sqsTransportConfiguration);

        var sqs = new AmazonSQSClient();
        
        foreach (var sqsProducerConfiguration in sqsTransportConfiguration.ProducerConfigurations)
        {
            messagingConfiguration.Services.AddSingleton<IProducerPipeline>(
                new SqsProducerPipeline(sqs, sqsProducerConfiguration));
        }
        
        return messagingConfiguration;
    }
}
