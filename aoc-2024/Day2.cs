using aoc_2024.IO;
using aoc_2024.Utils;

namespace aoc_2024;

public class Day2(IPuzzleInputReader reader)
{
    public object RunPart1()
    {
        List<Record> reports = GetReports();

        var safeReports = reports
            .Where(r => r.IsSafe);

        return safeReports.Count();
    }

    public object RunPart2()
    {
        List<Record> reports = GetReports();

        var safeReports = reports
            .Where(r => r.IsSafe);

        var unsafeReports = reports
            .Where(r => !r.IsSafe);

        

        return 0;
    }

    List<Record> GetReports() => reader
            .GetPuzzleInput(2)
            .Split('\n', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)
            .Select(i => new Record(i))
            .ToList();
}

public class Record
{
    public Record(string line)
    {
        Levels = GetValuePairs(line.Split().Select(l => Convert.ToInt32(l)).ToList());
        IsSafe = AllDeltasSafe() && AllSameTrend();
    }

    public List<ValuePair> Levels { get; set; }

    public bool IsSafe { get; set; }

    bool AllDeltasSafe() => Levels.All(l => l.IsDeltaValid);

    bool AllSameTrend() => Levels.All(l => l.Trend == Trend.Increasing) || Levels.All(l => l.Trend == Trend.Decreasing);

    List<ValuePair> GetValuePairs(List<int> levels)
    {
        List<ValuePair> pairs = new List<ValuePair>();
        for (int i = 0; i < levels.Count - 1; i++)
        {
            pairs.Add(new(levels[i], levels[i + 1]));
        }

        return pairs;
    }
}

public struct ValuePair(int a, int b)
{
    public int First { get; set; } = a;
    public int Second { get; set; } = b;

    int _delta = a - b;

    public readonly bool IsDeltaValid
    {
        get
        {
            int abs = Math.Abs(_delta);
            return abs > 0 && abs <= 3;
        }
    }
    
    public readonly Trend Trend
    {
        get
        {
            if (_delta < 0)
                return Trend.Increasing;
            else if (_delta > 0)
                return Trend.Decreasing;
            else
                return Trend.Neutral;
        }
    }
}

public enum Trend
{
    Increasing,
    Neutral,
    Decreasing
}