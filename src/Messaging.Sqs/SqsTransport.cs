using Amazon.SQS;

namespace Messaging.Sqs;

internal class SqsTransport(IAmazonSQS sqs, IMessageSerializer messageSerializer) : ITransport
{
    public Task SendAsync(object message)
    {
        throw new NotImplementedException();
    }
}