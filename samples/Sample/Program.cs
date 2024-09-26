using Messaging;
using Messaging.DependencyInjection;
using Messaging.Kafka.DependencyInjection;
using Messaging.Outgoing;
using Microsoft.AspNetCore.Mvc;
using Sample.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging =>
{
    messaging.Message<AccountCreatedMessage>("account-created");
    
    messaging.AddKafka(kafka =>
    {
        kafka.Destination("account-created", producer => producer
            .Handles<AccountCreatedMessage>()
            .WithBatchSize(100));
    });
});

var app = builder.Build();

app.MapPost("/accounts", async (
    [FromServices] IMessageBus messageBus,
    [FromBody] AccountCreatedMessage message) =>
{
    await messageBus.SendAsync(new OutgoingMessageEnvelope(message));

    return Results.Ok();
});

app.Run();
