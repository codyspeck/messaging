using Amazon.SQS;
using Microsoft.Extensions.Hosting;

namespace Messaging.Sqs;

internal class SqsProducerInitializer(
    IAmazonSQS sqs,
    SqsProducerConfiguration configuration,
    IHostEnvironment environment) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Get queue ARN
        
        // Create queue in development if not exists
        
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}