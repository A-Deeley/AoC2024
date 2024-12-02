using aoc_2024;
using aoc_2024.IO;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2024_tests;

public class Day2Tests
{
    readonly Day2 day;
    readonly string sample =
        """
        7 6 4 2 1
        1 2 7 8 9
        9 7 6 2 1
        1 3 2 4 5
        8 6 4 4 1
        1 3 6 7 9
        """;

    public Day2Tests()
    {
        var inputReader = Substitute.For<IPuzzleInputReader>();
        inputReader.GetPuzzleInput(2).Returns(sample);

        day = new(inputReader);
    }

    [Fact]
    public void TestPart1()
    {
        var actual = day.RunPart1();

        Assert.Equal(2, actual);
    }

    [Fact]
    public void TestPart2()
    {
        var actual = day.RunPart2();

        Assert.Equal(4, actual);
    }
}
