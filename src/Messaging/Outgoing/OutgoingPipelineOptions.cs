namespace Messaging.Outgoing;

internal class OutgoingPipelineOptions(int batchSize, IEnumerable<Type> messageTypes)
{
    public int BatchSize { get; } = batchSize;

    public HashSet<Type> MessageTypes { get; } = messageTypes.ToHashSet();
}
