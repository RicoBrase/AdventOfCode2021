using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day06
{
    public static class Day06Common
    {

        public static List<Lanternfish> ParseInput(string input)
        {
            return input
                .Trim()
                .Split(',')
                .Select(it => Convert.ToInt32(it))
                .Select(it => new Lanternfish(it))
                .ToList();
        }
        
        public static List<Lanternfish> SimulateXDays(List<Lanternfish> listOfLanternfish, int days)
        {
            var listOfFishs = new List<Lanternfish>();
            var newSpawnedFish = new List<Lanternfish>();
            
            listOfFishs.AddRange(listOfLanternfish);

            for (var i = 0; i < days; i++)
            {
                foreach (var fish in listOfFishs)
                {
                    var spawnedFish = fish.Tick();
                    if (spawnedFish is not null)
                    {
                        newSpawnedFish.Add(spawnedFish);
                    }
                }

                listOfFishs.AddRange(newSpawnedFish);
                newSpawnedFish.Clear();
            }

            return listOfFishs;
        }

    }
}