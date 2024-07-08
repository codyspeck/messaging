using Amazon.SQS;

namespace Messaging.Sqs;

internal class SqsProducerPipeline(IAmazonSQS sqs, SqsProducerConfiguration configuration) : IProducerPipeline
{
    public string Queue => configuration.QueueName;

    public IEnumerable<Type> MessageTypes => configuration.MessageTypes;

    public async Task ProduceAsync(Envelope envelope)
    {
        await sqs.SendMessageAsync(configuration.QueueName, envelope.MessageBody);
    }
}
