namespace Messaging.DependencyInjection;

public class MessagingConfiguration
{
    internal List<(string, Type)> MessageTypes { get; } = [];
    
    internal List<ITransport> Transports { get; } = [];
    
    public MessagingConfiguration Message<TMessage>(string messageTypeIdentifier)
    {
        MessageTypes.Add((messageTypeIdentifier, typeof(TMessage)));
        return this;
    }
}
