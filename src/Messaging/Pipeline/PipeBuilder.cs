namespace Messaging.Pipeline;

internal class PipeBuilder<TContext>
{
    private readonly List<IFilter<TContext>> _filters = [];

    public PipeBuilder<TContext> Use(IFilter<TContext> filter)
    {
        _filters.Add(filter);
        return this;
    }

    public IPipe<TContext> Build() => new Pipe<TContext>(_filters);
}
