namespace Messaging.Outgoing;

internal class OutgoingMessageRouter(IEnumerable<OutgoingPipeline> pipelines)
{
    public OutgoingPipeline Route(OutgoingMessageEnvelope envelope)
    {
        return pipelines.First(pipeline => pipeline.Handles(envelope));
    }
}
