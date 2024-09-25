namespace Messaging.Outgoing;

public interface IMessageSender
{
    Task SendAsync(IEnumerable<OutgoingMessageEnvelope> envelopes);
}
