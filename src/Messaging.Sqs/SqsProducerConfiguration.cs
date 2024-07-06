namespace Messaging.Sqs;

public class SqsProducerConfiguration
{
    private readonly HashSet<Type> _messageTypes = [];
    
    internal string Queue { get; }

    internal int BatchSize { get; private set; } = 10;

    internal int MaxDegreeOfParallelism { get; private set; } = 1;

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

    public SqsProducerConfiguration WithBatchSize(int batchSize)
    {
        BatchSize = batchSize;
        return this;
    }

    public SqsProducerConfiguration WithMaxDegreeOfParallelism(int maxDegreeOfParallelism)
    {
        MaxDegreeOfParallelism = maxDegreeOfParallelism;
        return this;
    }
}
