using System.Threading.Tasks.Dataflow;
using Messaging.Dataflow;

namespace Messaging.Outgoing.Sending;

internal class BatchSendAlgorithm : ISendAlgorithm
{
    private readonly ITargetBlock<OutgoingMessageEnvelope> _targetBlock;

    public BatchSendAlgorithm(IMessageSender sender, BatchSendOptions options)
    {
        var batch = CustomBlocks.TimedBatchBlock<OutgoingMessageEnvelope>(options.BatchSize, Defaults.BatchWaitTime);

        var action = new ActionBlock<OutgoingMessageEnvelope[]>(async envelopes =>
            await SendOutgoingMessageEnvelopes(sender, envelopes));

        batch.LinkTo(action);

        _targetBlock = batch;
    }

    public async Task SendAsync(OutgoingMessageEnvelope envelope)
    {
        await _targetBlock.SendAsync(envelope);

        await envelope.TaskCompletionSource.Task;
    }

    private static async Task SendOutgoingMessageEnvelopes(IMessageSender sender, OutgoingMessageEnvelope[] envelopes)
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
    }
}
