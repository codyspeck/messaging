using Messaging.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Incoming.Pipeline;

public class ConsumeFilter(IServiceProvider services, Type consumerType) : IFilter<IncomingMessageEnvelope>
{
    public async Task InvokeAsync(IncomingMessageEnvelope context, RequestDelegate next)
    {
        await using var scope = services.CreateAsyncScope();

        var consumer = (IConsumer)scope.ServiceProvider.GetRequiredService(consumerType);

        await consumer.ConsumeAsync(context.Message!);
    }
}
