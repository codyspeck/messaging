using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public class MessagingConfigurationBuilder
{
    internal MessagingConfigurationBuilder(IServiceCollection services)
    {
        Services = services;
    }

    internal IServiceCollection Services { get; }
}
