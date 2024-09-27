namespace Messaging.Outgoing.Sending;

internal interface ISendAlgorithm
{
    Task SendAsync(OutgoingMessageEnvelope envelope);
}
