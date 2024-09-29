using Confluent.Kafka;
using Messaging.DependencyInjection;
using Messaging.Kafka.Outgoing;
using Messaging.Outgoing;
using Messaging.Outgoing.Pipeline;
using Messaging.Outgoing.Sending;
using Messaging.Pipeline;
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
                new ProducerBuilder<Null, string>(clientConfig).Build(),
                kafkaSenderOptions);

            var sendAlgorithm = new BatchSendAlgorithm(
                kafkaMessageSender,
                new BatchSendOptions(destination.BatchSize));

            services.AddSingleton(provider => new OutgoingMessagePipeRegistration(
                new ServicePipeBuilder<OutgoingMessageEnvelope>()
                    .Use<TraceFilter>()
                    .Use<MessageTypeFilter>()
                    .Use<MessageSerializeFilter>()
                    .Use(new SendFilter(sendAlgorithm))
                    .Build(provider),
                new OutgoingMessagePipeRoutingMetadata(
                    destination.ExplicitDestination,
                    destination.MessageTypes)));
        }
    }
}
