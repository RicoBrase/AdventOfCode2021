using System;
using System.IO;

namespace AdventOfCode._2021.Day02
{
    public class Day02Part2 : IDay
    {
        private const string INPUT = "inputs/day02_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var listOfCommands = Day02Common.GetListOfCommandsByProcessingInput(input);
            var (finalHorizontal, _, finalDepth) = Day02Common.CalculatePositionByCommandInput_Part2(listOfCommands);

            Console.WriteLine("Final location of submarine:");
            Console.WriteLine($"\tHorizontal: {finalHorizontal}");
            Console.WriteLine($"\tDepth: {finalDepth}");
            Console.WriteLine($"\tTotal: {finalDepth * finalHorizontal}");
        }

        
        
    }
}