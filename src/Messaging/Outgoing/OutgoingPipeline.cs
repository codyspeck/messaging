using System.Threading.Tasks.Dataflow;
using Messaging.Dataflow;

namespace Messaging.Outgoing;

internal class OutgoingPipeline
{
    private readonly ITargetBlock<OutgoingMessageEnvelope> _targetBlock;
    private readonly OutgoingPipelineOptions _options;

    public OutgoingPipeline(IMessageSender sender, OutgoingPipelineOptions options)
    {
        _options = options;
        
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

    public bool Handles(OutgoingMessageEnvelope envelope)
    {
        return _options.MessageTypes.Contains(envelope.Message.GetType());
    }
    
    public async Task SendAsync(OutgoingMessageEnvelope envelope)
    {
        await _targetBlock.SendAsync(envelope);

        await envelope.TaskCompletionSource.Task;
    }
}
