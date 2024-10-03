using Messaging.Pipeline;

namespace Messaging.Incoming;

internal class IncomingMessageRouter
{
    private readonly MessageTypeRegistry _registry;
    private readonly Dictionary<Type, IPipe<IncomingMessageEnvelope>> _pipes = [];
    
    public IncomingMessageRouter(MessageTypeRegistry registry, IEnumerable<IncomingMessagePipeRegistration> registrations)
    {
        _registry = registry;
        
        foreach (var registration in registrations)
        {
            foreach (var messageType in registration.RoutingMetadata.MessageTypes)
            {
                _pipes.Add(messageType, registration.Pipe);
            }
        }        
    }
    
    public IPipe<IncomingMessageEnvelope> Route(IncomingMessageEnvelope envelope)
    {
        return envelope.ExplicitMessageType is not null
            ? _pipes[envelope.ExplicitMessageType]
            : _pipes[_registry.Get(envelope.Headers[MessageHeaders.MessageType]!).MessageType];
    }    
}
