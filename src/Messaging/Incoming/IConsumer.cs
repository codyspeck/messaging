// namespace Messaging.Incoming;
//
// public interface IConsumer
// {
//     Task ConsumeAsync(object message, IMessageContext context);
// }
//
// public interface IConsumer<in TMessage> : IConsumer
// {
//     Task ConsumeAsync(TMessage message, IMessageContext context);
//
//     Task IConsumer.ConsumeAsync(object message, IMessageContext context)
//     {
//         return ConsumeAsync((TMessage)message, context);
//     }
// }
