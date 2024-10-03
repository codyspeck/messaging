using Messaging.DependencyInjection;
using Messaging.Kafka.DependencyInjection;
using Sample.Features.CreateAccount;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging =>
{
    messaging.AddMessage<CreateAccountMessage>("account-created");

    messaging.AddConsumer<CreateAccountConsumer>(consumer => consumer
        .HandlesMessage<CreateAccountMessage>());
    
    messaging.AddKafka(kafka =>
    {
        kafka.AddDestination("account-created-topic", producer => producer
            .HandlesMessage<CreateAccountMessage>()
            .WithBatchSize(100));

        kafka.AddSource("account-created-topic", _ => { });
    });
});

var app = builder.Build();

app.MapCreateAccountEndpoint();

app.Run();
