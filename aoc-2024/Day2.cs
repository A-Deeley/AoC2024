using aoc_2024.IO;
using aoc_2024.Utils;

namespace aoc_2024;

public class Day2(IPuzzleInputReader reader)
{
    public object RunPart1()
    {
        List<List<int>> reports = reader.GetPuzzleInput(2).SplitOnNewlines().Select(i => i.Split(" ").Select(i => Convert.ToInt32(i)).ToList()).ToList();
        Dictionary<int, bool> reportStates = new();

        for (int reportIndex = 0; reportIndex < reports.Count; reportIndex++)
        {
            List<int>? report = reports[reportIndex];
            Direction? dir = null;
            int prev = 0;
            bool safe = true;

            for (int i = 0; i < report.Count; i++)
            {
                if (i == 0)
                {
                    prev = report[i];
                    continue;
                }

                int current = report[i];

                var newDir = ComparePreviousForDirection(prev, current);

                if (dir is null)
                    dir = newDir;
                else if (newDir != dir)
                {
                    prev = report[i];
                    safe = false;
                    break;
                }

                var delta = Math.Abs(prev - current);

                if (delta == 0)
                {
                    prev = report[i];
                    safe = false;
                    break;
                }

                if (delta > 3)
                {
                    prev = report[i];
                    safe = false;
                    break;
                }

                prev = report[i];
            }
            reportStates.Add(reportIndex, safe);
        }
        return reportStates.Count(kvPair => kvPair.Value);
    }

    public object RunPart2()
    {
        List<List<int>> reports = reader.GetPuzzleInput(2).SplitOnNewlines().Select(i => i.Split(" ").Select(i => Convert.ToInt32(i)).ToList()).ToList();
        Dictionary<int, bool> reportStates = new();

        for (int reportIndex = 0; reportIndex < reports.Count; reportIndex++)
        {
            List<int>? report = reports[reportIndex];
            Direction? trend = ComparePreviousForDirection(report[0], report[1]);
            int? unsafeIndex = trend == Direction.Neutral ? 0 : null;
            bool removedLevel = unsafeIndex is not null;
            if (unsafeIndex is not null)
            {
                report = report[1..];
                unsafeIndex = null;
            }

            for (int i = 0; i < report.Count - 1; i++)
            {
                int current = report[i];
                int next = report[i + 1];
                bool rebreak = false;

                if (trend != ComparePreviousForDirection(current, next))
                    unsafeIndex = i;

                if (!DeltaIsValid(current, next))
                    unsafeIndex = i;

                while (!removedLevel && unsafeIndex is int index)
                {
                    List<int> reportCopy = [.. report];
                    reportCopy.RemoveAt(index);

                    for (int j = 0; j < reportCopy.Count - 1; j++)
                    {
                        int _current = reportCopy[j];
                        int _next = reportCopy[j + 1];

                        if (trend != ComparePreviousForDirection(_current, _next))
                            rebreak = true;

                        if (!DeltaIsValid(_current, _next))
                            rebreak = true;
                    }

                    if (rebreak)
                        break;
                    else
                        unsafeIndex = null;
                }

                if (removedLevel && rebreak)
                    break;
                else if (rebreak)
                    removedLevel = true;

            }

            reportStates.Add(reportIndex, !removedLevel || (removedLevel && unsafeIndex == null));
        }
        return reportStates.Count(kvPair => kvPair.Value);
    }

    static Direction ComparePreviousForDirection(int prev, int current)
    {
        if (prev < current) return Direction.Increasing;

        if (prev == current) return Direction.Neutral;

        return Direction.Decreasing;
    }

    static bool DeltaIsValid(int prev, int current)
    {
        int delta = Math.Abs(prev - current);

        return 0 < delta && delta <= 3;
    }
}




public enum Direction
{
    Increasing,
    Neutral,
    Decreasing
}