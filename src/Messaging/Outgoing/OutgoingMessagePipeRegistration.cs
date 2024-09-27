using Messaging.Pipeline;

namespace Messaging.Outgoing;

internal class OutgoingMessagePipeRegistration(
    IPipe<OutgoingMessageEnvelope> pipe,
    OutgoingMessagePipeRoutingMetadata routingMetadata)
{
    public IPipe<OutgoingMessageEnvelope> Pipe { get; } = pipe;

    public OutgoingMessagePipeRoutingMetadata RoutingMetadata { get; } = routingMetadata;
}
