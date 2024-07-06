using System.Text.Json;

namespace Messaging;

internal class DefaultMessageSerializer : IMessageSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    public string Serialize(object message)
    {
        return JsonSerializer.Serialize(message, Options);
    }
}
