namespace Messaging.Outgoing;

internal class OutgoingPipelineOptions(int batchSize)
{
    public int BatchSize { get; } = batchSize;
}
