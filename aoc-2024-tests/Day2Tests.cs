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
    readonly IPuzzleInputReader _inputReader;
    readonly string sample =
        """
        
        """;

    public Day2Tests()
    {
        _inputReader = Substitute.For<IPuzzleInputReader>();
        _inputReader.GetPuzzleInput(2).Returns(sample);
    }

}
