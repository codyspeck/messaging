using System.Diagnostics;
using Messaging.Pipeline;

namespace Messaging.Outgoing.Pipeline;

public class TraceFilter : IFilter<OutgoingMessageEnvelope>
{
    public async Task InvokeAsync(OutgoingMessageEnvelope context, RequestDelegate next)
    {
        var activity = Activity.Current;

        if (activity is not null)
        {
            context.Headers[MessageHeaders.TraceParent] = activity.Id;
            context.Headers[MessageHeaders.TraceState] = activity.TraceStateString;
        }
        
        await next();
    }
}
