// namespace Messaging.Incoming;
//
// public interface IBatchConsumer
// {
//     Task ConsumeAsync(IEnumerable<(object Message, IMessageContext Context)> messages);
// }
//
// public interface IBatchConsumer<TMessage> : IBatchConsumer
// {
//     Task ConsumeAsync(IEnumerable<(TMessage message, IMessageContext context)> messages);
//
//     Task IBatchConsumer.ConsumeAsync(IEnumerable<(object Message, IMessageContext Context)> messages)
//     {
//         return ConsumeAsync(messages.Select(message => ((TMessage)message.Message, message.Context)));
//     }
// }
