using System.Text;
using Confluent.Kafka;
using Messaging.Incoming;

namespace Messaging.Kafka.Incoming;

internal static class IncomingMessageEnvelopeExtensions
{
    public static IncomingMessageEnvelope WithHeaders(this IncomingMessageEnvelope envelope, Headers headers)
    {
        foreach (var header in headers)
        {
            envelope.Headers.Add(header.Key, Encoding.ASCII.GetString(header.GetValueBytes()));
        }

        return envelope;
    }
}
