namespace Messaging;

internal class MessageRegistry
{
    private readonly Dictionary<string, Type> _types = [];
    private readonly Dictionary<Type, string> _identifiers = [];

    public void Add<TMessage>(string messageTypeIdentifier)
    {
        _types.Add(messageTypeIdentifier, typeof(TMessage));
        _identifiers.Add(typeof(TMessage), messageTypeIdentifier);
    }
}
