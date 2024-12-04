using aoc_2024;
using aoc_2024.IO;
using NSubstitute;

namespace aoc_2024_tests;

public class Day4Tests
{
    string sample = "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";
    Day4 day;

    public Day4Tests()
    {
        IPuzzleInputReader reader = Substitute.For<IPuzzleInputReader>();
        reader.GetPuzzleInput(4).Returns(sample);

        day = new(reader);
    }


    [Fact]
    public void TestPart1()
    {
        var actual = day.RunPart1();

        Assert.Equal(18, actual);
    }

    [Fact]
    public void TestPart2()
    {

        var actual = day.RunPart2();

        Assert.Null(actual);
    }
}
