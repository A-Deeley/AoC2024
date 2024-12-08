using aoc_2024;
using aoc_2024.IO;

IPuzzleInputReader reader = new FilePuzzleInputReader("C:/AdventOfCode", 2024);

Day1 day1 = new(reader);
Console.WriteLine("Day 1");
Console.WriteLine($"\tPart 1: {day1.RunPart1()}");
Console.WriteLine($"\tPart 2: {day1.RunPart2()}");
Console.WriteLine();

Day2 day2 = new(reader);
Console.WriteLine("Day2");
Console.WriteLine($"\tPart 1: {day2.RunPart1()}");
Console.WriteLine($"\tPart 2: {day2.RunPart2()}");
Console.WriteLine();

Day3 day3 = new(reader);
Console.WriteLine("Day3");
Console.WriteLine($"\tPart 1: {day3.RunPart1()}");
Console.WriteLine($"\tPart 2: {day3.RunPart2()}");
Console.WriteLine();

Day4 day4 = new(reader);
Console.WriteLine("Day4");
Console.WriteLine($"\tPart 1: {day4.RunPart1()}");
Console.WriteLine($"\tPart 2: {day4.RunPart2()}");
Console.WriteLine();

Day5 day5 = new(reader);
Console.WriteLine("Day5");
Console.WriteLine($"\tPart 1: {day5.RunPart1()}");
//Console.WriteLine($"\tPart 2: {day5.RunPart2()}");
Console.WriteLine();