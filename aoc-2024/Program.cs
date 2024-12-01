using aoc_2024;
using aoc_2024.IO;

IPuzzleInputReader reader = new FilePuzzleInputReader();

Day1 day1 = new(reader);
Console.WriteLine("Day 1");
Console.WriteLine($"\tPart 1: {day1.RunPart1()}");
Console.WriteLine($"\tPart 2: {day1.RunPart2()}");