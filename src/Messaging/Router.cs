namespace Messaging;

internal interface IRouter
{
    IEnumerable<IProducerPipeline> Route(Envelope envelope);
}

internal class Router(IEnumerable<IProducerPipeline> producerPipelines) : IRouter
{    
    public IEnumerable<IProducerPipeline> Route(Envelope envelope)
    {
        return envelope.ExplicitDestination.IsNotNullOrWhitespace()
            ? producerPipelines.Where(pipeline => pipeline.Queue.EqualsOrdinalIgnoreCase(envelope.ExplicitDestination))
            : producerPipelines.Where(pipeline => pipeline.MessageTypes.Contains(envelope.MessageType));
    }
}
