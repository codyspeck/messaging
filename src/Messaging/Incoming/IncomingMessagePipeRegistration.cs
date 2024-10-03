using Messaging.Pipeline;

namespace Messaging.Incoming;

internal class IncomingMessagePipeRegistration(
    IPipe<IncomingMessageEnvelope> pipe,
    IncomingMessagePipeRoutingMetadata routingMetadata)
{
    public IPipe<IncomingMessageEnvelope> Pipe { get; } = pipe;

    public IncomingMessagePipeRoutingMetadata RoutingMetadata { get; } = routingMetadata;
}
