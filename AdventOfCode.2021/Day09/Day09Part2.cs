using System;
using System.IO;

namespace AdventOfCode._2021.Day09
{
    public class Day09Part2 : IDay
    {
        private const string INPUT = "inputs/day09_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var heightMap = Day09Common.ParseInputToHeightMap(input);
            var allBasins = Day09Common.GetAllBasins(heightMap);
            var biggestThreeBasinSizes = Day09Common.GetSizesOfThreeBiggestBasins(allBasins);
            
            Console.WriteLine($"Sizes of three biggest basins multiplied: {biggestThreeBasinSizes.Multiply()}");
        }
    }
}