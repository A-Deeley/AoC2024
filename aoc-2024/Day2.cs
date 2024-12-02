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

                var newDir = ComparePrevious(prev, current);

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
            Direction? dir = null;
            int prev = 0;
            int safe = 1;

            for (int i = 0; i < report.Count; i++)
            {
                if (i == 0)
                {
                    prev = report[i];
                    continue;
                }

                int current = report[i];

                var newDir = ComparePrevious(prev, current);

                if (dir is null)
                    dir = newDir;
                else if (newDir != dir)
                {
                    prev = report[i];
                    if (safe-- == 0)
                        break;
                    else
                        safe--;
                }

                var delta = Math.Abs(prev - current);

                if (delta == 0)
                {
                    prev = report[i];
                    if (safe-- == 0)
                        break;
                    else
                        safe--;
                }

                if (delta > 3)
                {
                    prev = report[i];
                    if (safe-- == 0)
                        break;
                    else
                        safe--;
                }

                prev = safe == 1 ? report[i] : prev;
            }
            reportStates.Add(reportIndex, safe >= 0);
        }
        return reportStates.Count(kvPair => kvPair.Value);
    }

    static Direction ComparePrevious(int prev, int current)
    {
        if (prev < current) return Direction.Increasing;

        if (prev == current) return Direction.Neutral;

        return Direction.Decreasing;
    }
}




public enum Direction
{
    Increasing,
    Neutral,
    Decreasing
}