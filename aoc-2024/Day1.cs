using aoc_2024.IO;
using aoc_2024.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2024;

public class Day1(IPuzzleInputReader reader)
{
    readonly List<string> input = reader.GetPuzzleInput(1).SplitOnNewlines();

    public object RunPart1()
    {
        var t = input.Select(i =>
        {
            var row = i.Split("   ");
            return new { left = row[0], right = row[1] };
        });

        var locationIdList = new LocationIdList(t.Select(t => t.left), t.Select(t => t.right));
        int totalDistance = 0;

        for (int i = 0; i < locationIdList.Length; i++)
        {
            totalDistance += locationIdList.GetDifference(i);
        }

        return totalDistance.ToString();
    }

    public object RunPart2()
    {
        var t = input.Select(i =>
        {
            var row = i.Split("   ");
            return new { left = row[0], right = row[1] };
        });

        var locationIdList = new LocationIdList(t.Select(t => t.left), t.Select(t => t.right));
        int similarityScore = 0;

        foreach (int leftNumber in locationIdList.Left)
        {
            similarityScore += leftNumber * locationIdList.GetOccurences(leftNumber);
        }

        return similarityScore.ToString();
    }
}

internal struct LocationIdList(IEnumerable<string> left, IEnumerable<string> right)
{
    public readonly int Length { get; } = left.Count();

    public readonly List<int> Left { get; } = [.. left.Select(s => Convert.ToInt32(s)).OrderBy(i => i)];
    public readonly List<int> Right { get; } = [.. right.Select(s => Convert.ToInt32(s)).OrderBy(i => i)];

    public readonly int GetDifference(int index) => Math.Abs(Left[index] - Right[index]);

    public readonly int GetOccurences(int number) => Right.Count(n => n == number);
}