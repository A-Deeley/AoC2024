namespace aoc_2024.Utils;

internal static class InputUtils
{
    internal static List<string> SplitOnNewlines(this string input)
    {
        return [.. input.Split("\n")];
    }
}
