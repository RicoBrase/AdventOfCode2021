using System;
using System.IO;

namespace AdventOfCode._2021.Day12;

public class Day12Part2 : IDay
{
    private const string INPUT = "inputs/day12_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllLines(INPUT);
        var (caves, connections) = Day12Common.ParseInput(input);
        var countOfPaths = Day12Common
            .GetPathsThroughSmallCavesOnlyOnceAndASingleOneTwice(caves, connections)
            .Count;
        
        Console.WriteLine($"Count of paths trough cave system that visit small caves at most once, but a single small cave up to twice: {countOfPaths}");

    }
}