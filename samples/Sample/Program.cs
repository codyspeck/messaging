using Messaging;
using Messaging.Sqs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging => messaging
    .AddSqs(sqs => sqs
        .ProduceToSqsQueue("product-messages", producer => producer
            .HandlesMessageType<ProductCreated>())));

var app = builder.Build();

app.Run();

public record ProductCreated(string Sku);
