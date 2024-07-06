namespace Messaging;

public interface IMessageSerializer
{
    string Serialize(object message);
}
