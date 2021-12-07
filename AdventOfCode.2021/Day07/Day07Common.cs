using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day07
{
    public static class Day07Common
    {

        public static List<int> ParseInput(string input)
        {
            return input
                .Trim()
                .Split(',')
                .Select(it => Convert.ToInt32(it))
                .ToList();
        }

        public static int GetLeastAmountOfFuelNeeded(List<int> crabs)
        {
            var fuelNeed = new Dictionary<int, int>();
            var minPos = crabs.Min();
            var maxPos = crabs.Max();

            for (var position = minPos; position <= maxPos; position++)
            {
                fuelNeed.Add(position, crabs.Select(it => Utils.Max(it, position) - Utils.Min(it, position)).Sum());
            }
            
            return fuelNeed.Values.Min();
        }

    }
}