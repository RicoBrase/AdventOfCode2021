using System;
using System.IO;

namespace AdventOfCode._2021.Day15;

public class Day15Part1 : IDay
{
    private const string INPUT = "inputs/day15_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllLines(INPUT);
        var (caveGraph, caveWidth, caveHeight) = Day15Common.ParseInput(input);

        var lowestTotalCost = Navigator.FindPathWithLowestTotalRisk(caveGraph, caveWidth, caveHeight);
        
        Console.WriteLine($"Lowest total risk: {lowestTotalCost}");

    }
}