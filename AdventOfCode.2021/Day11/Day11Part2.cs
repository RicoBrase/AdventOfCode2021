using System;
using System.IO;

namespace AdventOfCode._2021.Day11;

public class Day11Part2 : IDay
{
    private const string INPUT = "inputs/day11_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllLines(INPUT);
        var board = Day11Common.ParseInput(input);
        var stepsUntilFlashesSync = Day11Common.RunUntilFlashesSync(board);
        
        Console.WriteLine($"Steps required until flashes sync: {stepsUntilFlashesSync}");
    }
}