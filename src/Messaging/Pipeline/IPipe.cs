namespace Messaging.Pipeline;

public interface IPipe<in TContext>
{
    Task SendAsync(TContext context);
}
