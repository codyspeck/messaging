using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public class MessagingConfiguration
{
    private readonly MessageRegistry _messageRegistry = new();
    
    internal MessagingConfiguration(IServiceCollection services)
    {
        Services = services;
    }

    internal IServiceCollection Services { get; }

    public MessagingConfiguration Consumer<TConsumer>(Action<ConsumerConfiguration<TConsumer>> configurator)
        where TConsumer : IConsumer
    {
        configurator(new ConsumerConfiguration<TConsumer>());
        return this;
    }
    
    public MessagingConfiguration Message<TMessage>(string routingKey)
    {
        _messageRegistry.Add<TMessage>(routingKey);
        return this;
    }
}
