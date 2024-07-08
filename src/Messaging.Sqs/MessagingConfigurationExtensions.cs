using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Messaging.Sqs;

public static class MessagingConfigurationExtensions
{
    public static MessagingConfiguration AddSqsTransport(this MessagingConfiguration messagingConfiguration,
        Action<SqsTransportConfiguration> configurator)
    {
        var sqsTransportConfiguration = new SqsTransportConfiguration();

        configurator(sqsTransportConfiguration);

        var sqs = new AmazonSQSClient(new AnonymousAWSCredentials(), new AmazonSQSConfig
        {
            ServiceURL = "http://localhost:4566"
        });
        
        foreach (var sqsProducerConfiguration in sqsTransportConfiguration.ProducerConfigurations)
        {
            messagingConfiguration.Services.AddSingleton<IProducerPipeline>(
                new SqsProducerPipeline(sqs, sqsProducerConfiguration));
                
            messagingConfiguration.Services.AddSingleton<IHostedService>(services => new SqsProducerInitializer(
                    sqs,
                    sqsProducerConfiguration,
                    services.GetRequiredService<IHostEnvironment>()));
        }
        
        return messagingConfiguration;
    }
}
