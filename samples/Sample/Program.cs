using Messaging;
using Messaging.Kafka;
using Sample.Consumers;
using Sample.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging =>
{
    messaging.Message<AccountCreatedMessage>("account-created");

    messaging.Consumer<AccountCreatedConsumer>(consumer => consumer
        .Handles<AccountCreatedMessage>()
        .BoundedCapacity(1)
        .MaxDegreeOfParallelism(1));
    
    messaging.AddKafka(kafka =>
    {
    });
});

var app = builder.Build();

app.Run();
