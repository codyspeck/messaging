namespace Messaging;

internal static class StringExtensions
{
    public static bool EqualsOrdinalIgnoreCase(this string? source, string? target)
    {
        return string.Equals(source, target, StringComparison.OrdinalIgnoreCase);
    }
    
    public static bool IsNotNullOrWhitespace(this string? source)
    {
        return !string.IsNullOrWhiteSpace(source);
    }
}
