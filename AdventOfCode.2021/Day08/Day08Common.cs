using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day08
{
    public static class Day08Common
    {

        public static List<(List<string> signalPatterns, List<string> outputValues)> ParseInput(string[] input)
        {
            return input.Select(ParseLine).ToList();
        }

        private static (List<string> signalPatterns, List<string> outputValues) ParseLine(string input)
        {
            var lineData = input
                .Split('|')
                .Select(it => it
                    .Trim()
                    .Split(' ')
                    .ToList()
                )
                .ToList();
            
            return (lineData.First(), lineData.Last());
        }

        public static int CountSimpleDigits_Part1(
            List<(List<string> signalPatterns, List<string> outputValues)> listOfInputs)
        {
            return listOfInputs
                .Select(it => it.outputValues)
                .SelectMany(it => it)
                .Select(it => it.Length)
                .Count(it => it is 2 or 4 or 3 or 7);
        }
        
    }
}