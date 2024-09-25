namespace Messaging;

internal interface ITransport
{
    Task SendAsync(object message);
}
