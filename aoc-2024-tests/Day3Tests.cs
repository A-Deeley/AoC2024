using aoc_2024;
using aoc_2024.IO;
using NSubstitute;

namespace aoc_2024_tests;

public class Day3Tests
{
    string sample1 = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    string sample2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
    IPuzzleInputReader reader;

    public Day3Tests()
    {
        reader = Substitute.For<IPuzzleInputReader>();
    }


    [Fact]
    public void TestPart1()
    {
        reader.GetPuzzleInput(3).Returns(sample1);
        Day3 day = new(reader);
        var actual = day.RunPart1();

        Assert.Equal(161, actual);
    }

    [Fact]
    public void TestPart2()
    {
        reader.GetPuzzleInput(3).Returns(sample2);
        Day3 day = new(reader);

        var actual = day.RunPart2();

        Assert.Equal(48, actual);
    }
}
