using Confluent.Kafka;
using Messaging.Pipeline;
using Microsoft.Extensions.Hosting;

namespace Messaging.Kafka.Incoming;

internal class KafkaMessagePoller(string topic, ClientConfig clientConfig, IPipe<KafkaConsumeContext> pipe)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Application startup is blocked until the asynchronous context is yielded.
        // This is necessary because the Kafka SDK's "Consume" method is synchronous. 
        await Task.Yield();

        var consumerConfig = new ConsumerConfig(clientConfig)
        {
            GroupId = "default",
            EnableAutoOffsetStore = false
        };

        var oi = new OffsetCoordinator();
        
        using var consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
        
        consumer.Subscribe(topic);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = consumer.Consume(stoppingToken);
            
            await pipe.SendAsync(new KafkaConsumeContext(consumeResult));
        }
    }
}
