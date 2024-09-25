namespace Messaging.Kafka.Outgoing;

internal class KafkaMessageSenderOptions(string topic)
{
    public string Topic { get; } = topic;
}
