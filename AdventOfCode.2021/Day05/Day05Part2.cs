using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day05
{
    public class Day05Part2 : IDay
    {
        private const string INPUT = "inputs/day05_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var lines = Day05Common.ParseInput(input);
            var oceanFloor = new OceanFloor();
            
            lines.ForEach(oceanFloor.AddLine);

            var floorData = oceanFloor.Build_Part2();
            var multipleOverlapsOnFloor = floorData.SelectMany(it => it).Count(it => it >= 2);
            
            Console.WriteLine($"number of points where at least two lines overlap: {multipleOverlapsOnFloor}");

        }
    }
}