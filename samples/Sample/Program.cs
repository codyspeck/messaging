using Messaging;
using Messaging.Sqs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging => messaging
    .AddSqsTransport(sqs => sqs
        .ProduceToSqsQueue("products", producer => producer
            .CreateOnStartupInDevelopment()
            .Handles<ProductCreated>()
            .WithBatchSize(10)
            .WithMaxDegreeOfParallelism(1))));

var app = builder.Build();

app.MapPost("/products", async (
    [FromServices] IMessageBus bus,
    [FromBody] ProductCreated message) =>
{
    await bus.SendAsync(message);
});

app.Run();

public record ProductCreated(string Sku);
