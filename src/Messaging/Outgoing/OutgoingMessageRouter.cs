namespace Messaging.Outgoing;

internal class OutgoingMessageRouter
{
    private readonly Dictionary<string, OutgoingPipeline> _explicitDestinations = [];
    private readonly Dictionary<Type, OutgoingPipeline> _messageTypes = [];
    
    public OutgoingMessageRouter(IEnumerable<OutgoingPipelineRegistration> registrations)
    {
        foreach (var registration in registrations)
        {
            if (!string.IsNullOrWhiteSpace(registration.RoutingMetadata.ExplicitDestination))
            {
                _explicitDestinations.Add(registration.RoutingMetadata.ExplicitDestination, registration.Pipeline);
            }

            foreach (var messageType in registration.RoutingMetadata.MessageTypes)
            {
                _messageTypes.Add(messageType, registration.Pipeline);
            }
        }
    }
    
    public OutgoingPipeline Route(OutgoingMessageEnvelope envelope)
    {
        return !string.IsNullOrWhiteSpace(envelope.ExplicitDestination)
            ? _explicitDestinations[envelope.ExplicitDestination]
            : _messageTypes[envelope.Message.GetType()];
    }
}
