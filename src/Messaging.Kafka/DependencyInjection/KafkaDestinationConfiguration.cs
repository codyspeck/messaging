namespace Messaging.Kafka.DependencyInjection;

public class KafkaDestinationConfiguration
{
    internal KafkaDestinationConfiguration(string topic)
    {
        Topic = topic;
    }

    internal string Topic { get; }

    internal string? ExplicitDestination { get; private set; }
    
    internal int BatchSize { get; private set; } = 1;

    internal int BatchWaitTimeInMilliseconds { get; private set; } = 1;

    internal List<Type> MessageTypes { get; } = [];

    public KafkaDestinationConfiguration HandlesMessage<TMessage>()
    {
        MessageTypes.Add(typeof(TMessage));
        return this;
    }

    public KafkaDestinationConfiguration WithBatchSize(int batchSize)
    {
        BatchSize = batchSize;
        return this;
    }

    public KafkaDestinationConfiguration WithBatchWaitTimeInMilliseconds(int batchWaitTimeInMilliseconds)
    {
        BatchWaitTimeInMilliseconds = batchWaitTimeInMilliseconds;
        return this;
    }
    
    public KafkaDestinationConfiguration WithExplicitDestination(string explicitDestination)
    {
        ExplicitDestination = explicitDestination;
        return this;
    }
}
