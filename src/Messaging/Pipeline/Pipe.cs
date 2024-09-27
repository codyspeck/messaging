namespace Messaging.Pipeline;

public class Pipe<TContext> : IPipe<TContext>
{
    private static RequestDelegate Null => () => Task.CompletedTask;
    
    private readonly LinkedList<IFilter<TContext>> _filters = [];

    public Pipe(IEnumerable<IFilter<TContext>> filters)
    {
        foreach (var filter in filters)
        {
            _filters.AddLast(filter);
        }
    }
    
    public async Task SendAsync(TContext context)
    {
        await BuildRequestDelegate(context, _filters.First)();
    }

    private static RequestDelegate BuildRequestDelegate(TContext context, LinkedListNode<IFilter<TContext>>? node)
    {
        return node is null ? Null : () => node.Value.InvokeAsync(context, BuildRequestDelegate(context, node.Next));
    }
}
