using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace aoc_2024.IO;

public class FilePuzzleInputReader(string? directory = null) : IPuzzleInputReader
{
    readonly string currentYearDirectory = directory ?? Path.Combine(GetFolderPath(SpecialFolder.MyDocuments), "AdventOfCode/2024");

    public string GetPuzzleInput(int day)
    {
        return File.ReadAllText(Path.Combine(currentYearDirectory, $"{day}.txt")).Trim();
    }
}
