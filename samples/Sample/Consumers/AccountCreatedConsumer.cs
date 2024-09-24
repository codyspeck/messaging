using Messaging;
using Sample.Messages;

namespace Sample.Consumers;

public class AccountCreatedConsumer : IConsumer<AccountCreatedMessage>
{
    public Task ConsumeAsync(AccountCreatedMessage message, IMessageContext context)
    {
        throw new NotImplementedException();
    }
}
