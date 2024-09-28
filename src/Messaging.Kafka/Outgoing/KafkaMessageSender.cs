using System.Text;
using System.Text.Json;
using Confluent.Kafka;
using Messaging.Outgoing;
using Messaging.Outgoing.Sending;

namespace Messaging.Kafka.Outgoing;

internal class KafkaMessageSender(IProducer<Null, string> producer, KafkaMessageSenderOptions options) : IMessageSender
{
    public async Task SendAsync(OutgoingMessageEnvelope envelope)
    {
        await producer.ProduceAsync(options.Topic, new Message<Null, string>
        {
            Headers = BuildHeaders(envelope),
            Value = JsonSerializer.Serialize(envelope.Message)
        });
    }

    public async Task SendAsync(IEnumerable<OutgoingMessageEnvelope> envelopes)
    {
        await Task.WhenAll(envelopes.Select(async envelope =>
        {
            try
            {
                await producer.ProduceAsync(options.Topic, new Message<Null, string>
                {
                    Headers = BuildHeaders(envelope),
                    Value = JsonSerializer.Serialize(envelope.Message)
                });
            }
            catch (Exception exception)
            {
                envelope.TaskCompletionSource.SetException(exception);
            }
        }));
    }

    private static Headers BuildHeaders(OutgoingMessageEnvelope envelope)
    {
        var headers = new Headers();
        
        foreach (var header in envelope.Headers)
        {
            headers.Add(header.Key, Encoding.ASCII.GetBytes(header.Value ?? string.Empty));
        }

        return headers;
    }
}
