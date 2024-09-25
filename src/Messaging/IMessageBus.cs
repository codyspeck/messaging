using Messaging.Outgoing;

namespace Messaging;

public interface IMessageBus
{
    Task SendAsync(OutgoingMessageEnvelope envelope);
}
