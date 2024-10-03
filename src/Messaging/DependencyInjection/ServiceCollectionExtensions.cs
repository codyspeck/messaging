using Messaging.Incoming;
using Messaging.Incoming.Pipeline;
using Messaging.Outgoing;
using Messaging.Outgoing.Pipeline;
using Messaging.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(
        this IServiceCollection services,
        Action<MessagingConfiguration> configurator)
    {
        var configuration = new MessagingConfiguration();

        configurator.Invoke(configuration);

        RegisterServices(services, configuration);
        
        return services;
    }

    private static void RegisterServices(IServiceCollection services, MessagingConfiguration configuration)
    {
        services.AddSingleton(new MessageTypeRegistry(configuration.MessageTypes));
        services.AddSingleton<IMessageSerializer, DefaultMessageSerializer>();
        services.AddSingleton<IMessageBus, MessageBus>();
        services.AddSingleton<IncomingMessageRouter>();
        services.AddSingleton<OutgoingMessageRouter>();
        services.AddSingleton<DeserializeFilter>();
        services.AddSingleton<MessageSerializeFilter>();
        services.AddSingleton<MessageTypeFilter>();
        services.AddSingleton<TraceFilter>();

        foreach (var consumer in configuration.Consumers)
        {
            services.Add(new ServiceDescriptor(consumer.ConsumerType, consumer.ConsumerType, ServiceLifetime.Scoped));
            
            services.AddSingleton(provider => new IncomingMessagePipeRegistration(
                new ServicePipeBuilder<IncomingMessageEnvelope>()
                    .Use<DeserializeFilter>()
                    .Use(provider2 => new ConsumeFilter(provider2, consumer.ConsumerType))
                    .Build(provider),
                new IncomingMessagePipeRoutingMetadata(consumer.MessageTypes)));
        }
        
        foreach (var transport in configuration.Transports)
        {
            transport.RegisterServices(services);
        }
    }
}
