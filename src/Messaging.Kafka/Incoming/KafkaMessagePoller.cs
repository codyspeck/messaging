using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace Messaging.Kafka.Incoming;

internal class KafkaMessagePoller(IConsumer<Null, string> consumer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Application startup is blocked until the asynchronous context is yielded.
        // This is necessary because the Kafka SDK's "Consume" method is synchronous. 
        await Task.Yield();
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = consumer.Consume(stoppingToken);
            
            
        }
    }
}
