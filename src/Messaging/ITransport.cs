namespace Messaging;

internal interface ITransport
{
    Task SendAsync(Envelope envelope);
}
