using Messaging.DependencyInjection;
using Messaging.Kafka.Outgoing;
using Messaging.Outgoing;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Kafka.DependencyInjection;

internal class KafkaTransport(KafkaConfiguration configuration) : ITransport
{
    public void RegisterServices(IServiceCollection services)
    {
        var clientConfig = configuration.BuildClientConfig();
        
        foreach (var destination in configuration.Destinations)
        {
            var kafkaSenderOptions = new KafkaMessageSenderOptions(destination.Topic);

            var kafkaMessageSender = new KafkaMessageSender(
                clientConfig,
                kafkaSenderOptions);

            var outgoingPipelineRoutingMetadata = new OutgoingPipelineRoutingMetadata(
                destination.ExplicitDestination,
                destination.MessageTypes);

            var outgoingPipelineOptions = new OutgoingPipelineOptions(destination.BatchSize);
            
            var outgoingPipeline = new OutgoingPipeline(kafkaMessageSender, outgoingPipelineOptions);

            var outgoingPipelineRegistration = new OutgoingPipelineRegistration(
                outgoingPipeline,
                outgoingPipelineRoutingMetadata);
            
            services.AddSingleton(outgoingPipelineRegistration);
        }
    }
}
