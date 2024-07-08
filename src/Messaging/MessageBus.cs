namespace Messaging;

public interface IMessageBus
{
    Task SendAsync(object message);

    Task SendAsync(Message message);
}

internal class MessageBus(IEnveloper enveloper, IRouter router) : IMessageBus
{
    public async Task SendAsync(object message)
    {
        var envelope = enveloper.Envelope(message);

        await router
            .Route(envelope)
            .Select(pipeline => pipeline.ProduceAsync(envelope))
            .WhenAll();
    }

    public async Task SendAsync(Message message)
    {
        var envelope = enveloper.Envelope(message);

        await router
            .Route(envelope)
            .Select(pipeline => pipeline.ProduceAsync(envelope))
            .WhenAll();
    }
}
