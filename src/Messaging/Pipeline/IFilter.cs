namespace Messaging.Pipeline;

public delegate Task RequestDelegate();

public interface IFilter<in TContext>
{
    Task InvokeAsync(TContext context, RequestDelegate next);
}
