using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public class MessagingConfiguration
{
    private readonly ICollection<object> _endpointConfigurations = [];
    
    internal IServiceCollection Services { get; }

    internal IEnumerable<object> EndpointConfigurations => _endpointConfigurations;

    internal MessagingConfiguration(IServiceCollection services)
    {
        Services = services;
    }
    
    internal void AddEndpointConfiguration(object endpointConfiguration)
    {
        _endpointConfigurations.Add(endpointConfiguration);
    }
}
