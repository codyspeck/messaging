using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace Messaging.Kafka.Incoming;

internal class KafkaPoller(IConsumer<Null, string> consumer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();
        
        while (!stoppingToken.IsCancellationRequested)
        {
            // var consumeResult = consumer.Consume();
            //
            // consumeResult.Message.Headers
        }
    }
}
