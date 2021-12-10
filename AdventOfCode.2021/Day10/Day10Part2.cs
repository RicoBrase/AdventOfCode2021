using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day10;

public class Day10Part2 : IDay
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
        var score = GetAutocompleteScores(input).Middle();

        Console.WriteLine($"Middle score: {score}");
    }
 
    public static long GetAutocompleteScore(List<ChunkInputCharacter> chars)
    {
        return chars.Select(c => c switch
            {
                ChunkInputCharacter.ParenthesesClose => (int) AutocompleteScore.ParenthesesClose,
                ChunkInputCharacter.BracketsClose => (int) AutocompleteScore.BracketsClose,
                ChunkInputCharacter.BracesClose => (int) AutocompleteScore.BracesClose,
                ChunkInputCharacter.ChevronsClose => (int) AutocompleteScore.ChevronsClose,
                _ => throw new ArgumentOutOfRangeException()
            })
            .Aggregate(0L, (current, charVal) => current * 5L + charVal);
    } 
    
    public static List<long> GetAutocompleteScores(string[] input)
    {
        return input.Select(line =>
            {
                var parser = new ChunkParser(line);
                return parser.RunAndGetAutocompleteChars();
            })
            .Where(chars => chars.Count > 0)
            .ToList()
            .Select(GetAutocompleteScore)
            .ToList();
    }

    
}