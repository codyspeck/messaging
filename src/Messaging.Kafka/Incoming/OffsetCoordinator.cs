using Confluent.Kafka;

namespace Messaging.Kafka.Incoming;

internal interface IOffsetCoordinator
{
    void StoreOffset(TopicPartitionOffset topicPartitionOffset);
}

internal class OffsetCoordinator(IConsumer<Null, string> consumer)
{
    private readonly Dictionary<int, SortedList<long, TopicPartitionOffset>> _things = [];
    private readonly IConsumer<Null, string> _consumer = consumer;

    public void StoreOffset(TopicPartitionOffset topicPartitionOffset)
    {
        if (!_things.TryGetValue(topicPartitionOffset.Partition, out var things))
        {
            _things.TryAdd(topicPartitionOffset.Partition, new SortedList<long, TopicPartitionOffset>());
        }

        things ??= _things[topicPartitionOffset.Partition];

        things.Add(topicPartitionOffset.Offset, topicPartitionOffset);
    }
}
