using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public class MessagingConfiguration
{
    internal IServiceCollection Services { get; }

    internal MessagingConfiguration(IServiceCollection services)
    {
        Services = services;
    }
}
