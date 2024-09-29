namespace Messaging;

public interface IMessageSerializer
{
    string Serialize(object message);

    object Deserialize(string serializedMessage, Type messageType);
}
