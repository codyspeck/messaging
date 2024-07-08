using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services,
        Action<MessagingConfiguration> configurator)
    {
        var configuration = new MessagingConfiguration(services);

        configurator(configuration);

        services.AddSingleton<IEnveloper, Enveloper>();
        services.AddSingleton<IMessageBus, MessageBus>();
        services.AddSingleton<IMessageSerializer, DefaultMessageSerializer>();
        services.AddSingleton<IRouter, Router>();
        
        return services;
    }
}
