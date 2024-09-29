namespace Messaging;

internal static class Defaults
{
    public const int BoundedCapacity = 100;

    public const int MaxDegreeOfParallelism = 1;
    
    public static TimeSpan BatchWaitTime = TimeSpan.FromMilliseconds(20);    
}
