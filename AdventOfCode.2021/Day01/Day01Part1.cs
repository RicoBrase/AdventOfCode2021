using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public static class Day01Part1
    {
        private const string INPUT_DAY01_1 = "inputs/day01_1_input.txt";
        
        public static void Main(string[] args)
        {
            if (!File.Exists(INPUT_DAY01_1))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT_DAY01_1).Select(it => Convert.ToInt32(it)).ToList();
            var comparisons = Day01Common.CompareDepthMeasurements(input);
            var countLargerMeasurements = Day01Common.HowManyMeasurementsAreLargerThanPreviousMeasurement(comparisons);
            
            Console.WriteLine($"There are {countLargerMeasurements} measurements, that are larger than the previous one.");
        }

        
        
    }
}