using System;
using System.IO;

namespace AdventOfCode._2021.Day11;

public class Day11Part1 : IDay
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
        var flashes = 0;
        for (var i = 0; i < 100; i++)
        {
            flashes += Day11Common.RunSingleSimulationStepAndReturnCountOfFlashes(board);
        }
        
        Console.WriteLine($"Sum of flashes after 100 steps: {flashes}");
    }
}