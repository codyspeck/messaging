using Confluent.Kafka;
using Messaging.Kafka.Outgoing;
using Messaging.Outgoing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Messaging.Kafka;

public class KafkaConfigurationBuilder
{
    private readonly MessagingConfiguration _messagingConfiguration;
    
    internal KafkaConfigurationBuilder(MessagingConfiguration messagingConfiguration)
    {
        _messagingConfiguration = messagingConfiguration;
    }

    public KafkaConfigurationBuilder SendTo(
        string topic,
        Func<ProducerConfigurationBuilder, ProducerConfigurationBuilder> configurator)
    {
        var producerConfiguration = configurator(new ProducerConfigurationBuilder(topic))
            .Build();
        
        _messagingConfiguration.Services.TryAddSingleton<KafkaMessageSender>();
        _messagingConfiguration.Services.AddSingleton<OutgoingPipeline>(services =>
            CreateOutgoingPipeline(services, producerConfiguration));

        return this;
    }

    private static OutgoingPipeline CreateOutgoingPipeline(
        IServiceProvider services,
        ProducerConfiguration producerConfiguration)
    {
        var clientConfiguration = services.GetRequiredService<ClientConfig>();

        var producer = new ProducerBuilder<Null, string>(clientConfiguration)
            .Build();

        var messageSender = new KafkaMessageSender(
            producer,
            new KafkaMessageSenderOptions(producerConfiguration.Topic));
        
        return new OutgoingPipeline(messageSender, new OutgoingPipelineOptions(100, producerConfiguration.MessageTypes));
    }
}
