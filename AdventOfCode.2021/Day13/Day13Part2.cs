using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day13;

public class Day13Part2 : IDay
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
        
        foreach (var fold in folds)
        {
            paper.Fold(fold);
        }

        var printablePaper = paper.Coordinates
            .Select(row => row
                .Select(it => it ? "#" : " ")
                .ToList()
            )
            .ToList();

        Console.WriteLine("Printing the 8-digit code to the console:");
        Console.WriteLine();
        
        foreach (var row in printablePaper)
        {
            var columnCounter = 0;
            foreach (var field in row)
            {
                Console.Write(field);
                columnCounter++;
                if(columnCounter % 5 == 0) Console.Write(" ");
            }
            Console.WriteLine();
        }

        // Console.WriteLine($"Count of visible dots visible after completing just the first fold: {dots}");

    }
}