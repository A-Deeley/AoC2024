namespace aoc_2024.Utils;

internal static class InputUtils
{
    internal static List<string> SplitOnNewlines(this string input)
    {
        return [.. input.Split("\r\n")];
    }

    internal static List<int> SplitOnNewlines<T>(this string input)
        where T : struct
    {
        return [.. input.Split("\n\r").Select(i => Convert.ToInt32(i))];
    }
}
