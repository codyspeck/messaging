namespace Messaging.Outgoing.Sending;

internal class SynchronousSendAlgorithm(IMessageSender sender) : ISendAlgorithm
{
    public async Task SendAsync(OutgoingMessageEnvelope envelope)
    {
        await sender.SendAsync(envelope);
    }
}
