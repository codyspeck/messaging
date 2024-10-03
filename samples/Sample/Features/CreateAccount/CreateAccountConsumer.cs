using System.Text.Json;
using Messaging.Incoming;

namespace Sample.Features.CreateAccount;

public class CreateAccountConsumer : IConsumer
{
    public Task ConsumeAsync(object message)
    {
        Console.WriteLine(JsonSerializer.Serialize(message));

        return Task.CompletedTask;
    }
}