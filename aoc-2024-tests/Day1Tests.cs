using aoc_2024;
using aoc_2024.IO;
using NSubstitute;

namespace aoc_2024_tests;

public class Day1Tests
{
    readonly Day1 day;
    readonly string sample =
        """
        3   4
        4   3
        2   5
        1   3
        3   9
        3   3
        """;

    public Day1Tests()
    {
        var inputReader = Substitute.For<IPuzzleInputReader>();
        inputReader.GetPuzzleInput(1).Returns(sample);

        day = new(inputReader);
    }

    [Fact]
    public void TestPart1()
    {
        Assert.Equal("11", day.RunPart1());
    }

    [Fact]
    public void TestPart2()
    {
        Assert.Equal("31", day.RunPart2());
    }
}