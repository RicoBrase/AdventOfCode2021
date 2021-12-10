using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day10;

public class Day10Part1 : IDay
{
    private const string INPUT = "inputs/day10_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllLines(INPUT);
        var errorScores = input
            .Select(line =>
            {
                var parser = new ChunkParser(line);
                return parser.RunAndGetScore().score;
            })
            .Select(it => (int)it)
            .Sum();
        
        Console.WriteLine($"Total syntax error score for corrupted lines: {errorScores}");
    }
}