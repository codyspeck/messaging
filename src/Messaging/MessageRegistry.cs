namespace Messaging;

internal class MessageRegistry
{
    private readonly Dictionary<string, Type> _routingKeyToMessageType = [];
    private readonly Dictionary<Type, string> _messageTypeToRoutingKey = [];

    public void Add<TMessage>(string routingKey)
    {
        _routingKeyToMessageType.Add(routingKey, typeof(TMessage));
        _messageTypeToRoutingKey.Add(typeof(TMessage), routingKey);
    }
}
