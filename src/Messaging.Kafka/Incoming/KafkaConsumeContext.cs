using Confluent.Kafka;

namespace Messaging.Kafka.Incoming;

internal class KafkaConsumeContext(ConsumeResult<Null, string> result)
{
    public string Message { get; } = result.Message.Value;

    public Dictionary<string, string?> Headers = result.Message.Headers.ToDictionary(
        a => a.Key,
        a => a.GetValueBytes().ToString());
}
