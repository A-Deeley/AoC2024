﻿using aoc_2024.IO;
using aoc_2024;
using NSubstitute;

namespace aoc_2024_tests;

public class Day5Tests
{
    readonly Day5 day;
    readonly string sample =
        "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";

    public Day5Tests()
    {
        var inputReader = Substitute.For<IPuzzleInputReader>();
        inputReader.GetPuzzleInput(5).Returns(sample);

        day = new(inputReader);
    }

    [Fact]
    public void TestPart1()
    {
        var actual = day.RunPart1();

        Assert.Equal(143, actual);
    }

    public void TestPart2()
    {
        var actual = day.RunPart2();

        Assert.Equal(4, actual);
    }
}