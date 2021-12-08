using System;
using System.IO;

namespace AdventOfCode._2021.Day08
{
    public class Day08Part1 : IDay
    {
        private const string INPUT = "inputs/day08_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var parsedData = Day08Common.ParseInput(input);
            var countOfWantedDigitsInOutputValues = Day08Common.CountSimpleDigits_Part1(parsedData);
            
            Console.WriteLine($"Count of digits 1, 4, 7 and 8 in the output values: {countOfWantedDigitsInOutputValues}");
        }
    }
}