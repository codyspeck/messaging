using System.Text.Json;
using Confluent.Kafka;
using Messaging.Outgoing;

namespace Messaging.Kafka.Outgoing;

internal class KafkaMessageSender(IProducer<Null, string> producer, KafkaMessageSenderOptions options) : IMessageSender
{
    public async Task SendAsync(IEnumerable<OutgoingMessageEnvelope> envelopes)
    {
        await Task.WhenAll(envelopes.Select(async envelope =>
        {
            try
            {
                await producer.ProduceAsync(options.Topic, new Message<Null, string>
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
