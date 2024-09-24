using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public class MessagingConfigurationBuilder
{
    private readonly Dictionary<string, Type> _routingKeys = [];
    
    internal MessagingConfigurationBuilder(IServiceCollection services)
    {
        Services = services;
    }

    internal IServiceCollection Services { get; }

    public MessagingConfigurationBuilder Consumer<TConsumer>(Action<ConsumerConfiguration<TConsumer>> configurator)
        where TConsumer : IConsumer
    {
        configurator(new ConsumerConfiguration<TConsumer>());
        return this;
    }
    
    public MessagingConfigurationBuilder Message<TMessage>(string routingKey)
    {
        _routingKeys.Add(routingKey, typeof(TMessage));
        return this;
    }
}
