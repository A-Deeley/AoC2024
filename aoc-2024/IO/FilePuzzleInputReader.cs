using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace aoc_2024.IO;

public class FilePuzzleInputReader(string? directory = null, int? year = null) : IPuzzleInputReader
{
    readonly string currentYearDirectory = directory ?? Path.Combine(GetFolderPath(SpecialFolder.MyDocuments), $"AdventOfCode");

    public string GetPuzzleInput(int day)
    {
        year ??= DateTime.Now.Year;
        return File.ReadAllText(Path.Combine(currentYearDirectory, $"{year}/{day}.txt")).Trim();
    }
}
