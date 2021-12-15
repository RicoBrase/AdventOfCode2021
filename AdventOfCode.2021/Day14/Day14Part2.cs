using System;
using System.IO;

namespace AdventOfCode._2021.Day14;

public class Day14Part2 : IDay
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

        var polymer = Day14Common.RunPolymerizationForXSteps(40, string.Join("", startingPolymer), insertionRules);

        var elementScore = Day14Common.GetElementScore_Part2(string.Join("", startingPolymer), polymer);
        
        Console.WriteLine($"Quantity of most common element subtracted by quantity of least common element after 40 steps: {elementScore}");

    }
}