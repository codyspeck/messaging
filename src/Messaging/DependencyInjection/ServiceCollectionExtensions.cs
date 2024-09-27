using Messaging.Outgoing;
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
        var registry = new MessageTypeRegistry(configuration.MessageTypes);
        
        services.AddSingleton<IMessageBus, MessageBus>();
        services.AddSingleton<OutgoingMessageRouter>();

        foreach (var transport in configuration.Transports)
        {
            transport.RegisterServices(services, registry);
        }
    }
}
