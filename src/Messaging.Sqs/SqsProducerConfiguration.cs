namespace Messaging.Sqs;

public class SqsProducerConfiguration
{
    private readonly HashSet<Type> _messageTypes = [];
    
    internal string QueueName { get; }

    internal string? QueueArn { get; private set; }

    internal int BatchSize { get; private set; } = 10;

    internal int MaxDegreeOfParallelism { get; private set; } = 1;

    internal bool ShouldCreateOnStartupInDevelopment { get; private set; } = false;

    internal IEnumerable<Type> MessageTypes => _messageTypes;
    
    internal SqsProducerConfiguration(string queueName)
    {
        QueueName = queueName;
    }

    public SqsProducerConfiguration CreateOnStartupInDevelopment()
    {
        ShouldCreateOnStartupInDevelopment = true;
        return this;
    }
    
    public SqsProducerConfiguration Handles<TMessage>()
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

    internal SqsProducerConfiguration WithQueueArn(string queueArn)
    {
        QueueArn = queueArn;
        return this;
    }
}
