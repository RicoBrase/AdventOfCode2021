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
        
        public static List<Lanternfish> SimulateXDays_Part1(List<Lanternfish> listOfLanternfish, int days)
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
        
        public static long SimulateXDays_Part2(List<Lanternfish> listOfLanternfish, int days)
        {
            var currentFishs = new Dictionary<int, long>();
            var nextFishs = new Dictionary<int, long>();

            foreach (var lanternfish in listOfLanternfish)
            {
                if (!currentFishs.ContainsKey(lanternfish.Timer))
                {
                    currentFishs.Add(lanternfish.Timer, 1);
                }
                else
                {
                    currentFishs[lanternfish.Timer]++;
                } 
            }

            for (var day = 1; day <= days; day++)
            {
                foreach (var timer in currentFishs.Keys)
                {
                    if (timer == 0)
                    {
                        nextFishs.TryGetValue(Lanternfish.RESET_TIMER_TO, out var previousVal);
                        nextFishs.Put(Lanternfish.INIT_TIMER_NEW_SPAWN, currentFishs[0]);
                        nextFishs.Put(Lanternfish.RESET_TIMER_TO, previousVal + currentFishs[0]);
                    }
                    else
                    {
                        nextFishs.TryGetValue(timer - 1, out var previousVal);
                        nextFishs.Put(timer - 1, previousVal + currentFishs[timer]);
                    }
                }

                currentFishs = new Dictionary<int, long>(nextFishs);
                nextFishs.Clear();
            }

            return currentFishs.Values.Sum();
        }

        private static void Put<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue val)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, val);
            }
            else
            {
                dict[key] = val;
            }
        }

    }
}