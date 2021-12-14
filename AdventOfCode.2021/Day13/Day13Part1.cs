using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day13;

public class Day13Part1 : IDay
{
    private const string INPUT = "inputs/day13_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllLines(INPUT);
        var (paper, folds) = Day13Common.ParseInput(input);
        var firstFold = folds.First();
        paper.Fold(firstFold);

        var dots = paper.Coordinates
            .SelectMany(it => it)
            .Count(it => it);

        Console.WriteLine($"Count of visible dots visible after completing just the first fold: {dots}");

    }
}