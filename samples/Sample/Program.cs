using Messaging;
using Messaging.Kafka;
using Sample.Consumers;
using Sample.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMessaging(messaging =>
{
    messaging.Message<AccountCreatedMessage>("account-created");

    // messaging.Consumer<AccountCreatedConsumer>(consumer => consumer
    //     .Handles<AccountCreatedMessage>()
    //     .BoundedCapacity(1000)
    //     .MaxDegreeOfParallelism(4));
    
    messaging.AddKafka(kafka =>
    {
        kafka.SendTo("account-created-topic", producer => producer
            .Handles<AccountCreatedMessage>());
    });
});

var app = builder.Build();

app.Run();
