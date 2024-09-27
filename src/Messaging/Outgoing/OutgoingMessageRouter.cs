using Messaging.Pipeline;

namespace Messaging.Outgoing;

internal class OutgoingMessageRouter
{
    private readonly Dictionary<string, IPipe<OutgoingMessageEnvelope>> _explicitDestinations = [];
    private readonly Dictionary<Type, IPipe<OutgoingMessageEnvelope>> _messageTypes = [];
    
    public OutgoingMessageRouter(IEnumerable<OutgoingMessagePipeRegistration> registrations)
    {
        foreach (var registration in registrations)
        {
            if (!string.IsNullOrWhiteSpace(registration.RoutingMetadata.ExplicitDestination))
            {
                _explicitDestinations.Add(registration.RoutingMetadata.ExplicitDestination, registration.Pipe);
            }

            foreach (var messageType in registration.RoutingMetadata.MessageTypes)
            {
                _messageTypes.Add(messageType, registration.Pipe);
            }
        }
    }
    
    public IPipe<OutgoingMessageEnvelope> Route(OutgoingMessageEnvelope envelope)
    {
        return !string.IsNullOrWhiteSpace(envelope.ExplicitDestination)
            ? _explicitDestinations[envelope.ExplicitDestination]
            : _messageTypes[envelope.Message.GetType()];
    }
}
