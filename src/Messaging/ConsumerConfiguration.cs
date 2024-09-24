namespace Messaging;

public class ConsumerConfiguration<TConsumer> where TConsumer : IConsumer
{
    private int _boundedCapacity = 1;
    private int _maxDegreeOfParallelism = 1;
    private readonly List<Type> _messageTypes = [];

    internal ConsumerConfiguration()
    {
    }

    public ConsumerConfiguration<TConsumer> BoundedCapacity(int boundedCapacity)
    {
        _boundedCapacity = boundedCapacity;
        return this;
    }
    
    public ConsumerConfiguration<TConsumer> Handles<TMessage>()
    {
        _messageTypes.Add(typeof(TMessage));
        return this;
    }

    public ConsumerConfiguration<TConsumer> MaxDegreeOfParallelism(int maxDegreeOfParallelism)
    {
        _maxDegreeOfParallelism = maxDegreeOfParallelism;
        return this;
    }
}
