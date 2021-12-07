using System;
using System.IO;

namespace AdventOfCode._2021.Day06
{
    public class Day06Part1 : IDay
    {
        private const string INPUT = "inputs/day06_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllText(INPUT);
            var listOfFish = Day06Common.ParseInput(input);
            var listOfFishAfterSimulation = Day06Common.SimulateXDays_Part1(listOfFish, 80);

            Console.WriteLine($"Count of lanternfish after 80 days: {listOfFishAfterSimulation.Count}");
        }
    }
}