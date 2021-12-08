using System;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day08
{
    public class Day08Part2 : IDay
    {
        private const string INPUT = "inputs/day08_input.txt";
        
        public void Run()
        {
            if (!File.Exists(INPUT))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input = File.ReadAllLines(INPUT);
            var parsedData = Day08Common.ParseInput(input);
            var outputSum = parsedData
                .Select(it =>
                {
                    var dict = Day08Common.BuildDictionaryForLine(it.signalPatterns);
                    return Day08Common.DecodeOutputValueDigitsWithDictionary(dict, it.outputValues);
                })
                .Select(it => Convert.ToInt32(it))
                .Sum();


            Console.WriteLine($"Summed output of each line: {outputSum}");
        }
    }
}