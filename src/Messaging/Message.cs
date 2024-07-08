namespace Messaging;

public class Message(object body)
{
    public object Body { get; } = body;

    public string? ExplicitDestination { get; private set; }

    public Message WithExplicitDestination(string explicitDestination)
    {
        ExplicitDestination = explicitDestination;
        return this;
    }
}
