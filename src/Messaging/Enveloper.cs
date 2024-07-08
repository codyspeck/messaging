namespace Messaging;

internal interface IEnveloper
{
    Envelope Envelope(object message);

    Envelope Envelope(Message message);
}

internal class Enveloper(IMessageSerializer messageSerializer) : IEnveloper
{
    public Envelope Envelope(object message)
    {
        var serializedMessage = messageSerializer.Serialize(message);

        return new Envelope(serializedMessage, null, message.GetType());
    }

    public Envelope Envelope(Message message)
    {
        var serializedMessage = messageSerializer.Serialize(message.Body);

        return new Envelope(serializedMessage, message.ExplicitDestination, message.Body.GetType());
    }
}
