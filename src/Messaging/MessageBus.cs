using Messaging.Outgoing;

namespace Messaging;

internal class MessageBus(OutgoingMessageRouter router) : IMessageBus
{
    public async Task SendAsync(OutgoingMessageEnvelope envelope)
    {
        await router
            .Route(envelope)
            .SendAsync(envelope);
    }
}
