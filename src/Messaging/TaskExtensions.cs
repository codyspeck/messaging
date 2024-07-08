namespace Messaging;

internal static class TaskExtensions
{
    public static async Task WhenAll(this IEnumerable<Task> tasks)
    {
        await Task.WhenAll(tasks);
    }
}
