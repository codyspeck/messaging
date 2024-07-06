# Messaging

Required features include:

- Amazon SQS transport
- Polymorphic queues
- Implicit batching
- User-defined batch size
- User-defined parallelism
- User-defined implicit batching timeout window

Example usage:

```c#
services.AddMessaging(messaging => messaging
    .ProduceToSqs("products", producer => producer
        .Handles<ProductCreatedMessage>()
        .BatchSize(10)));
```