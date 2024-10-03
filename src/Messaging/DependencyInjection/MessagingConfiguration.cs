using Messaging.Incoming;

namespace Messaging.DependencyInjection;

public class MessagingConfiguration
{
    internal List<ConsumerConfiguration> Consumers { get; } = [];

    internal List<(string, Type)> MessageTypes { get; } = [];
    
    internal List<ITransport> Transports { get; } = [];

    public MessagingConfiguration AddConsumer<TConsumer>(Action<ConsumerConfiguration> configurator)
        where TConsumer : IConsumer
    {
        var consumerConfiguration = new ConsumerConfiguration(typeof(TConsumer));
        configurator.Invoke(consumerConfiguration);
        Consumers.Add(consumerConfiguration);
        return this;
    }
    
    public MessagingConfiguration AddMessage<TMessage>(string messageTypeIdentifier)
    {
        MessageTypes.Add((messageTypeIdentifier, typeof(TMessage)));
        return this;
    }
}
