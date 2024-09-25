using System.Threading.Tasks.Dataflow;

namespace Messaging.Dataflow;

internal static class CustomBlocks
{
    public static IPropagatorBlock<T, T[]> TimedBatchBlock<T>(int batchSize, TimeSpan timeout)
    {
        var batchBlock = new BatchBlock<T>(batchSize);

        var timer = new Timer(_ => batchBlock.TriggerBatch());

        var actionBlock = new ActionBlock<T>(item =>
        {
            batchBlock.Post(item);

            timer.Change(timeout, Timeout.InfiniteTimeSpan);
        });

        return DataflowBlock.Encapsulate(actionBlock, batchBlock);
    }
}
