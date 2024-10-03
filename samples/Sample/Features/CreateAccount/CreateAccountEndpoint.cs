using Messaging;
using Messaging.Outgoing;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Features.CreateAccount;

public static class CreateAccountEndpoint
{
    public static void MapCreateAccountEndpoint(this WebApplication app)
    {
        app.MapPost("/accounts", async (
            [FromServices] IMessageBus bus,
            [FromBody] CreateAccountMessage message) =>
        {
            await bus.SendAsync(new OutgoingMessageEnvelope(message));
        });
    }
}
