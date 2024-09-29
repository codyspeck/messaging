namespace Messaging.Kafka;

internal class Wrapper<T>(T value)
{
    public T Value { get; } = value;
}
