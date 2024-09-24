namespace Messaging;

public class BatchConsumerConfiguration<TConsumer> where TConsumer : IBatchConsumer
{
    private readonly List<Type> _messageTypes = [];

    private int _batchSize = 1;
    private int _boundedCapacity = 1;
    private int _maxDegreeOfParallelism = 1;
    private TimeSpan _batchTimeout = TimeSpan.FromMilliseconds(200);

    internal BatchConsumerConfiguration()
    {
    }
    
    public BatchConsumerConfiguration<TConsumer> Handles<TMessage>()
    {
        _messageTypes.Add(typeof(TMessage));
        return this;
    }

    public BatchConsumerConfiguration<TConsumer> BatchSize(int batchSize)
    {
        _batchSize = batchSize;
        return this;
    }
}
