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
    public void TestPart1_ProvidedSample_ReturnsProvidedAnswer()
    {
        var actual = day.RunPart1();

        Assert.Equal(18, actual);
    }

    [Fact]
    public void TestPart1_BoundaryEdgeCase_DoesNotReturnFalseXmas()
    {
        string sample = "XXXX\nXXXM\nXXXX\nAXXX\nXSXX";
        IPuzzleInputReader _reader = Substitute.For<IPuzzleInputReader>();
        _reader.GetPuzzleInput(4).Returns(sample);
        Day4 _day = new(_reader);


        var actual = _day.RunPart1();

        Assert.Equal(0, actual);
    }

    [Fact]
    public void TestPart2()
    {

        var actual = day.RunPart2();

        Assert.Null(actual);
    }
}
