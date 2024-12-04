using aoc_2024.IO;
using aoc_2024.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2024;

public partial class Day3(IPuzzleInputReader reader)
{
    readonly string input = reader.GetPuzzleInput(3);

    public object RunPart1()
    {
        Regex findMulRegex = GetMultiplyOperationsPart1();

        var matches = findMulRegex.Matches(input);

        return matches.Select(PerformMultiplyOp).Sum();
         
        throw new NotImplementedException();
    }

    public object RunPart2()
    {
        Regex r = GetMultiplyOperationsPart2();
        var matches = r.Matches(input);

        bool enabled = true;
        int sum = 0;
        foreach (Match match in matches)
        {
            string matched = match.Value;
            if (enabled && matched.StartsWith("mul")) // This is a mul(x,y)
            {
                sum += PerformMultiplyOp(match);
                continue;
            }

            

            if (matched == "don't()")
            {
                enabled = false;
                continue;
            }

            if (matched == "do()")
            {
                enabled = true;
                continue;
            }
        }

        return sum;
    }

    [GeneratedRegex(@"mul\((?<left>\d*),(?<right>\d*)\)", RegexOptions.ExplicitCapture)]
    private static partial Regex GetMultiplyOperationsPart1();

    [GeneratedRegex(@"mul\((?<left>\d*),(?<right>\d*)\)|do\(\)|don\'t\(\)", RegexOptions.ExplicitCapture)]
    private static partial Regex GetMultiplyOperationsPart2();

    static int PerformMultiplyOp(Match match)
    {
        int left = Convert.ToInt32(match.Groups["left"].Value);
        int right = Convert.ToInt32(match.Groups["right"].Value);
    
        return left * right;
    }
}
