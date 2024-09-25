namespace Messaging;

public class ConsumerConfiguration
{
    private int _boundedCapacity = 1;
    private int _maxDegreeOfParallelism = 1;
    private readonly Type _consumerType;
    private readonly List<Type> _messageTypes = [];

    internal ConsumerConfiguration(Type consumerType)
    {
        _consumerType = consumerType;
    }

    public ConsumerConfiguration BoundedCapacity(int boundedCapacity)
    {
        _boundedCapacity = boundedCapacity;
        return this;
    }
    
    public ConsumerConfiguration Handles<TMessage>()
    {
        _messageTypes.Add(typeof(TMessage));
        return this;
    }

    public ConsumerConfiguration MaxDegreeOfParallelism(int maxDegreeOfParallelism)
    {
        _maxDegreeOfParallelism = maxDegreeOfParallelism;
        return this;
    }
}
