using Messaging;
using Messaging.Sqs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging => messaging
    .AddSqs(sqs => sqs));

var app = builder.Build();

app.Run();

public record ProductCreated(string Sku);
