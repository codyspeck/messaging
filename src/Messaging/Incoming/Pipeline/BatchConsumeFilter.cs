using System.Threading.Tasks.Dataflow;
using Messaging.Dataflow;
using Messaging.Pipeline;

namespace Messaging.Incoming.Pipeline;

internal class BatchConsumeFilter : IFilter<IncomingMessageEnvelope>
{
    private readonly ITargetBlock<IncomingMessageEnvelope> _block;

    public BatchConsumeFilter(IBatchConsumer batchConsumer)
    {
        var batchBlock = CustomBlocks.TimedBatchBlock<IncomingMessageEnvelope>(10, TimeSpan.Zero);

        var consumeBlock = new ActionBlock<IncomingMessageEnvelope[]>(async envelopes =>
        {
            try
            {
                await batchConsumer.ConsumeAsync(envelopes.Select(envelope => envelope.Message!));

                foreach (var envelope in envelopes)
                {
                    envelope.TaskCompletionSource.TrySetResult();
                }
            }
            catch (Exception exception)
            {
                foreach (var envelope in envelopes)
                {
                    envelope.TaskCompletionSource.TrySetException(exception);
                }   
            }
        });

        batchBlock.LinkTo(consumeBlock, new DataflowLinkOptions { PropagateCompletion = true });

        _block = batchBlock;
    }
    
    public async Task InvokeAsync(IncomingMessageEnvelope context, RequestDelegate next)
    {
        await _block.SendAsync(context);

        await context.TaskCompletionSource.Task;
    }
}
