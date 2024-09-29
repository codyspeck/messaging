using System.Text.Json;

namespace Messaging;

internal class DefaultMessageSerializer : IMessageSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    public string Serialize(object message)
    {
        return JsonSerializer.Serialize(message, Options);
    }

    public object Deserialize(string serializedMessage, Type messageType)
    {
        var message = JsonSerializer.Deserialize(serializedMessage, messageType, Options);

        if (message is null)
        {
            throw new InvalidOperationException();
        }

        return message;
    }
}
