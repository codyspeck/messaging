namespace Messaging.Outgoing.Sending;

internal class BatchSendOptions(int batchSize)
{
    public int BatchSize { get; } = batchSize;
}
