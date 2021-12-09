using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day09
{
    public class Day09Part1 : IDay
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
            var lowPoints = Day09Common.GetAllLowPoints(heightMap).Select(it => it.height).ToList();
            var riskLevels = Day09Common.TransformHeightDataToRiskLevel(lowPoints).Sum();
            
            Console.WriteLine($"Sum of risk levels of all low points: {riskLevels}");
        }
    }
}