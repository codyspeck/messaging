namespace Messaging;

internal interface IProducer
{
    Task ProduceAsync(Envelope envelope);
}
