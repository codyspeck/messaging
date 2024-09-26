namespace Messaging.Outgoing;

internal class OutgoingPipelineRegistration(OutgoingPipeline pipeline, OutgoingPipelineRoutingMetadata routingMetadata)
{
    public OutgoingPipeline Pipeline { get; } = pipeline;

    public OutgoingPipelineRoutingMetadata RoutingMetadata { get; } = routingMetadata;
}
