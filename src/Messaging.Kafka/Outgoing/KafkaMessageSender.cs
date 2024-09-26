using System.Text.Json;
using Confluent.Kafka;
using Messaging.Outgoing;

namespace Messaging.Kafka.Outgoing;

internal class KafkaMessageSender(ClientConfig clientConfig, KafkaMessageSenderOptions options) : IMessageSender
{
    private readonly IProducer<Null, string> _producer = new ProducerBuilder<Null, string>(clientConfig).Build();
    
    public async Task SendAsync(IEnumerable<OutgoingMessageEnvelope> envelopes)
    {
        await Task.WhenAll(envelopes.Select(async envelope =>
        {
            try
            {
                await _producer.ProduceAsync(options.Topic, new Message<Null, string>
                {
                    Value = JsonSerializer.Serialize(envelope.Message)
                });
            }
            catch (Exception exception)
            {
                envelope.TaskCompletionSource.SetException(exception);
            }
        }));
    }
}
