using Messaging.Pipeline;

namespace Messaging.Incoming;

internal class IncomingMessageRouter
{
    public IPipe<IncomingMessageEnvelope> Route(IncomingMessageEnvelope envelope)
    {
        throw new NotImplementedException();
    }    
}
