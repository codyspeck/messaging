namespace Messaging.Outgoing;

internal interface IMessageSender
{
    Task SendAsync(IEnumerable<OutgoingMessageEnvelope> envelopes);
}
