using System.Threading.Tasks.Dataflow;
using Messaging.Dataflow;

namespace Messaging.Outgoing;

internal class OutgoingPipeline
{
    private readonly ITargetBlock<OutgoingMessageEnvelope> _targetBlock;

    public OutgoingPipeline(IMessageSender sender, OutgoingPipelineOptions options)
    {
        var batch = CustomBlocks.TimedBatchBlock<OutgoingMessageEnvelope>(options.BatchSize, Defaults.BatchWaitTime);

        var action = new ActionBlock<OutgoingMessageEnvelope[]>(async envelopes =>
        {
            try
            {
                await sender.SendAsync(envelopes);

                envelopes.TrySetResult();
            }
            catch (Exception exception)
            {
                envelopes.TrySetException(exception);
            }
        });

        batch.LinkTo(action);

        _targetBlock = batch;
    }

    public async Task SendAsync(OutgoingMessageEnvelope envelope)
    {
        await _targetBlock.SendAsync(envelope);

        await envelope.TaskCompletionSource.Task;
    }
}
