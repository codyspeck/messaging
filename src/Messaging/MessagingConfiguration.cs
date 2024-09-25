using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public class MessagingConfiguration
{
    private readonly MessageRegistry _messageRegistry = new();
    private readonly List<ConsumerConfiguration> _consumerConfigurations = [];
    
    internal MessagingConfiguration(IServiceCollection services)
    {
        Services = services;
    }

    internal IServiceCollection Services { get; }

    public MessagingConfiguration Consumer<TConsumer>(Action<ConsumerConfiguration> configurator)
        where TConsumer : IConsumer
    {
        var consumerConfiguration = new ConsumerConfiguration(typeof(TConsumer));
        configurator(consumerConfiguration);
        _consumerConfigurations.Add(consumerConfiguration);
        return this;
    }
    
    public MessagingConfiguration Message<TMessage>(string routingKey)
    {
        _messageRegistry.Add<TMessage>(routingKey);
        return this;
    }
}
