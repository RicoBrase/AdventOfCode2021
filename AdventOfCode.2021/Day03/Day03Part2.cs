using System;
using System.IO;

namespace AdventOfCode._2021.Day03
{
    public class Day03Part2 : IDay
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
            var oxygenGeneratorRating =
                Day03Common.GetIntFromBinary(Day03Common.FindOxygenGeneratorRating_Part2(input));
            var co2ScrubberRating =
                Day03Common.GetIntFromBinary(Day03Common.FindCO2ScrubberRating_Part2(input));

            Console.WriteLine($"Oxygen Generator Rating: {oxygenGeneratorRating}");
            Console.WriteLine($"CO2 Scrubber Rating: {co2ScrubberRating}");
            Console.WriteLine($"Life Support Rating: {oxygenGeneratorRating*co2ScrubberRating}");
        }
    }
}