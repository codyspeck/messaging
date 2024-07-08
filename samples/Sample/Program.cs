using Messaging;
using Messaging.Sqs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging => messaging
    .AddSqsTransport(sqs => sqs
        .ProduceToSqsQueue("products", producer => producer
            .HandlesMessageType<ProductCreated>()
            .WithBatchSize(10)
            .WithMaxDegreeOfParallelism(1))));

var app = builder.Build();

app.Run();

public record ProductCreated(string Sku);
