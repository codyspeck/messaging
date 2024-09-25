namespace Messaging;

internal static class Defaults
{
    public static int BoundedCapacity = 100;

    public static int MaxDegreeOfParallelism = 1;
    
    public static TimeSpan BatchWaitTime = TimeSpan.FromMilliseconds(20);    
}
