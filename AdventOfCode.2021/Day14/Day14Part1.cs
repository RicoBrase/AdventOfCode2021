using System;
using System.IO;

namespace AdventOfCode._2021.Day14;

public class Day14Part1 : IDay
{
    private const string INPUT = "inputs/day14_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllLines(INPUT);
        var (startingPolymer, insertionRules) = Day14Common.ParseInput(input);

        var polymer = startingPolymer;
        for (var i = 0; i < 10; i++)
        {
            polymer = Day14Common.RunPolymerizationStep(polymer, insertionRules);
        }

        var elementScore = Day14Common.GetElementScore(polymer);
        
        Console.WriteLine($"Quantity of most common element subtracted by quantity of least common element: {elementScore}");

    }
}