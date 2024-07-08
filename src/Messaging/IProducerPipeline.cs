namespace Messaging;

internal interface IProducerPipeline
{
    string Queue { get; }

    IEnumerable<Type> MessageTypes { get; }

    Task ProduceAsync(Envelope envelope);
}
