using System;
using System.IO;

namespace AdventOfCode._2021.Day03
{
    public class Day03Part1 : IDay
    {
        private const string INPUT = "inputs/day03_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var gammaRate = Day03Common.GetIntFromBinary(Day03Common.GetGammaRateFromInput_Part1(input));
            var epsilonRate = Day03Common.GetIntFromBinary(Day03Common.GetEpsilonRateFromInput_Part1(input));
            
            Console.WriteLine($"Gamma Rate: {gammaRate}");
            Console.WriteLine($"Epsilon Rate: {epsilonRate}");
            Console.WriteLine($"Power Consumption: {gammaRate*epsilonRate}");
        }
    }
}