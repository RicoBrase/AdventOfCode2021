using System;
using System.IO;

namespace AdventOfCode._2021.Day07
{
    public class Day07Part1 : IDay
    {
        private const string INPUT = "inputs/day07_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllText(INPUT);
            var listOfCrabPositions = Day07Common.ParseInput(input);
            var leastFuelNeeded = Day07Common.GetLeastAmountOfFuelNeeded_Part1(listOfCrabPositions);
            
            Console.WriteLine($"Least fuel needed to align all crabs on one position: {leastFuelNeeded}");
        }
    }
}