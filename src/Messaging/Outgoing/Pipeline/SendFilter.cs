using Messaging.Outgoing.Sending;
using Messaging.Pipeline;

namespace Messaging.Outgoing.Pipeline;

internal class SendFilter(ISendAlgorithm sender) : IFilter<OutgoingMessageEnvelope>
{
    public async Task InvokeAsync(OutgoingMessageEnvelope context, RequestDelegate next)
    {
        await sender.SendAsync(context);
    }
}
