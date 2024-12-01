using aoc_2024.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2024;

public abstract class AdventDay(IPuzzleInputReader puzzleReader)
{
    protected readonly IPuzzleInputReader _puzzleInputReader = puzzleReader;
}
