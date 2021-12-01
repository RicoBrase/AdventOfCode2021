using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public class Day01Part1 : IDay
    {
        private const string INPUT = "inputs/day01_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT).Select(it => Convert.ToInt32(it)).ToList();
            var comparisons = Day01Common.CompareDepthMeasurements(input);
            var countLargerMeasurements = Day01Common.HowManyMeasurementsAreLargerThanPreviousMeasurement(comparisons);
            
            Console.WriteLine($"There are {countLargerMeasurements} measurements, that are larger than the previous one.");
        }

        
        
    }
}