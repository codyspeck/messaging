using Messaging.Outgoing;

namespace Messaging;

internal class MessageBus(OutgoingMessageRouter registry) : IMessageBus
{
    public async Task SendAsync(OutgoingMessageEnvelope envelope) => await registry
        .Route(envelope)
        .SendAsync(envelope);
}
