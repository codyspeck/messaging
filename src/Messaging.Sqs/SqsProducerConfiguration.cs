namespace Messaging.Sqs;

public class SqsProducerConfiguration
{
    private readonly HashSet<Type> _messageTypes = [];
    
    internal string Queue { get; }

    internal IEnumerable<Type> MessageTypes => _messageTypes;
    
    internal SqsProducerConfiguration(string queue)
    {
        Queue = queue;
    }

    public SqsProducerConfiguration HandlesMessageType<TMessage>()
    {
        _messageTypes.Add(typeof(TMessage));
        return this;
    }
}
