using Confluent.Kafka;

namespace Messaging.Kafka.Incoming;

internal class KafkaConsumeContext(ConsumeResult<Null, string> consumeResult)
{
    public ConsumeResult<Null, string> ConsumeResult { get; } = consumeResult;
}
