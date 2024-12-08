using aoc_2024.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2024;

public class Day5(IPuzzleInputReader reader)
{
    string input = reader.GetPuzzleInput(5);

    public object RunPart1()
    {
        List<string> rows = input.Split('\n').ToList();
        int indexOfSeparation = rows.IndexOf("");
        List<OrderingRule> rules = rows[0..indexOfSeparation].Select(r => new OrderingRule(r)).ToList();
        List<List<int>> updates = rows[(indexOfSeparation + 1)..].Select(r => r.Split(',').Select(int.Parse).ToList()).ToList();
        int sumOfMiddle = 0;

        for (int i = 0; i < updates.Count; i++)
        {
            bool isInRightOrder = true;
            List<int> current = updates[i];
            for (int p = 0; p < current.Count; p++)
            {
                int page = current[p];
                var applicableRules = rules.Where(r => r.HasPageNumber(page));
                if (!applicableRules.Any()) continue;

                foreach (var rule in applicableRules) 
                {
                    if (page == rule.First && current[..p].Contains(rule.Second))
                    {
                        isInRightOrder = false;
                        goto SkipUpdate;
                    }

                    if (page == rule.Second && current[p..].Contains(rule.First))
                    {
                        isInRightOrder = false;
                        goto SkipUpdate;
                    }
                }
            }

        SkipUpdate:
            if (isInRightOrder) sumOfMiddle += current[current.Count / 2];
        }

        return sumOfMiddle;
    }

    public object RunPart2()
    {
        throw new NotImplementedException();
    }

    public class OrderingRule
    {
        public OrderingRule(string rule)
        {
            string[] leftRight = rule.Split('|');
            First = int.Parse(leftRight[0]);
            Second = int.Parse(leftRight[1]);
        }

        public int First { get; set; }
        public int Second { get; set; }

        public bool HasPageNumber(int number) => First == number || Second == number;
    }
}
