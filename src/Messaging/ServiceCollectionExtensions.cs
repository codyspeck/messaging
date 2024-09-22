using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMessaging(
        this IServiceCollection services,
        Action<MessagingConfigurationBuilder> configurator)
    {
        var builder = new MessagingConfigurationBuilder(services);

        configurator(builder);
        
        return services;
    }
}
