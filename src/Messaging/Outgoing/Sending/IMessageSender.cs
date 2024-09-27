namespace Messaging.Outgoing.Sending;

internal interface IMessageSender
{
    Task SendAsync(OutgoingMessageEnvelope envelope);
    
    Task SendAsync(IEnumerable<OutgoingMessageEnvelope> envelopes);
}
