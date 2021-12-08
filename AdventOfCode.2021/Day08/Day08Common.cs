using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021.Day08
{
    public static class Day08Common
    {

        public static List<(List<string> signalPatterns, List<string> outputValues)> ParseInput(string[] input)
        {
            return input.Select(ParseLine).ToList();
        }

        public static (List<string> signalPatterns, List<string> outputValues) ParseLine(string input)
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

        public static Dictionary<string, int> BuildDictionaryForLine(List<string> signalPatterns)
        {
            var dict = new Dictionary<string, int>();

            signalPatterns = signalPatterns.Select(it => it.Sort()).ToList();

            var eight = Array.Empty<char>();
            var seven = Array.Empty<char>();
            var one = Array.Empty<char>();
            var four = Array.Empty<char>();
            
            foreach (var pattern in signalPatterns)
            {
                switch (pattern.Length)
                {
                    case 2:
                        dict.Add(pattern, 1);
                        one = pattern.ToCharArray();
                        break;
                    case 4:
                        dict.Add(pattern, 4);
                        four = pattern.ToCharArray();
                        break;
                    case 3:
                        dict.Add(pattern, 7);
                        seven = pattern.ToCharArray();
                        break;
                    case 7:
                        dict.Add(pattern, 8);
                        eight = pattern.ToCharArray();
                        break;
                }
            }
            
            var charOfTopBar = seven.Except(one).First();
            
            // build 9
            var stepBeforeNine = four.Append(charOfTopBar).ToArray();
            var nine = signalPatterns
                .Where(it => it.Length == 6)
                .First(it => it.Intersect(stepBeforeNine).Count() == stepBeforeNine.Length)
                .ToCharArray();
            
            dict.Add(string.Join("", nine), 9);

            var charOfBottomBar = nine.Except(stepBeforeNine).First();

            // build 3
            var stepBeforeThree = seven.Append(charOfBottomBar).ToArray();
            var three = signalPatterns
                .Where(it => it.Length == 5)
                .First(it => it.Intersect(stepBeforeThree).Count() == stepBeforeThree.Length)
                .ToCharArray();
            
            dict.Add(string.Join("", three), 3);

            var charOfBottomLeftBar = eight.Except(nine).First();
            
            // build 6
            var stepBeforeSix = eight.Except(one).ToArray();
            var six = signalPatterns
                .Where(it => it.Length == 6)
                .First(it => it.Intersect(stepBeforeSix).Count() == stepBeforeSix.Length)
                .ToCharArray();
            
            dict.Add(string.Join("", six), 6);
            
            // build 5
            var five = signalPatterns
                .Where(it => it.Length == 5)
                .First(it => six.Except(it).Count() == 1)
                .ToCharArray();
            
            dict.Add(string.Join("", five), 5);
            
            // build 0
            var zero = signalPatterns
                .Where(it => it.Length == 6)
                .First(it => eight.Except(it).Count() == 1 && it.Except(six).Any() && it.Except(nine).Any())
                .ToCharArray();
            
            dict.Add(string.Join("", zero), 0);

            var charOfMiddleBar = eight.Except(zero).First();
            var charOfTopRightBar = eight.Except(six).First();
            
            // build 2
            var two = new[]
            {
                charOfTopBar, charOfMiddleBar, charOfBottomBar, charOfBottomLeftBar, charOfTopRightBar
            };
            
            dict.Add(string.Join("", two).Sort(), 2);

            return dict;
        }

        public static string DecodeOutputValueDigitsWithDictionary(Dictionary<string, int> dict,
            List<string> outputValues)
        {
            var sb = new StringBuilder();

            foreach (var value in outputValues)
            {
                var sortedVal = value.Sort();
                if (dict.ContainsKey(sortedVal))
                {
                    sb.Append(dict[sortedVal]);
                }
            }

            return sb.ToString();
        }
    }
}