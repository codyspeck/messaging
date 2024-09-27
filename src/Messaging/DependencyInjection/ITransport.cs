using Microsoft.Extensions.DependencyInjection;

namespace Messaging.DependencyInjection;

internal interface ITransport
{
    void RegisterServices(IServiceCollection services, MessageTypeRegistry registry);
}
