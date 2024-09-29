using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Pipeline;

internal class ServicePipeBuilder<TContext>
{
    private readonly List<Func<IServiceProvider, IFilter<TContext>>> _filterFactories = [];

    public ServicePipeBuilder<TContext> Use<TFilter>() where TFilter : IFilter<TContext>
    {
        _filterFactories.Add(services => services.GetRequiredService<TFilter>());
        return this;
    }

    public ServicePipeBuilder<TContext> Use(IFilter<TContext> filter)
    {
        _filterFactories.Add(_ => filter);
        return this;
    }
    
    public IPipe<TContext> Build(IServiceProvider services)
    {
        return new Pipe<TContext>(_filterFactories.Select(factory => factory(services)));
    }
}
