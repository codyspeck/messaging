namespace Messaging;

internal class MessageTypeRegistry
{
    private readonly Dictionary<string, MessageTypeMetadata> _messageTypeIdentifiers = [];
    private readonly Dictionary<Type, MessageTypeMetadata> _messageTypes = [];

    public MessageTypeRegistry(IEnumerable<(string, Type)> messageTypes)
    {
        foreach (var (messageTypeIdentifier, messageType) in messageTypes)
        {
            var messageTypeMetadata = new MessageTypeMetadata(messageTypeIdentifier, messageType);
            _messageTypeIdentifiers.Add(messageTypeIdentifier, messageTypeMetadata);
            _messageTypes.Add(messageType, messageTypeMetadata);
        }
    }

    public MessageTypeMetadata Get(string messageTypeIdentifier) => _messageTypeIdentifiers[messageTypeIdentifier];

    public MessageTypeMetadata Get(Type messageType) => _messageTypes[messageType];
}
