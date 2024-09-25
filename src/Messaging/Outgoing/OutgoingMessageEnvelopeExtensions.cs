namespace Messaging.Outgoing;

internal static class OutgoingMessageEnvelopeExtensions
{
    public static void TrySetException(this IEnumerable<OutgoingMessageEnvelope> envelopes, Exception exception)
    {
        foreach (var envelope in envelopes)
        {
            envelope.TaskCompletionSource.TrySetException(exception);
        }
    }
    
    public static void TrySetResult(this IEnumerable<OutgoingMessageEnvelope> envelopes)
    {
        foreach (var envelope in envelopes)
        {
            envelope.TaskCompletionSource.TrySetResult();
        }
    }
}
