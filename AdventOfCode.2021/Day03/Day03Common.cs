using System;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021.Day03
{
    public static class Day03Common
    {

        public static string GetGammaRateFromInput_Part1(string[] inputLines)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < inputLines[0].Trim().Length; i++)
            {
                var countOnes = 0;
                var countZeros = 0;

                foreach (var line in inputLines)
                {
                    var c = line.ToCharArray()[i];
                    switch (c)
                    {
                        case '0':
                            countZeros++;
                            break;
                        case '1':
                            countOnes++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                sb.Append(countZeros >= countOnes ? '0' : '1');
            }

            return sb.ToString();
        }
        
        public static string GetEpsilonRateFromInput_Part1(string[] inputLines)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < inputLines[0].Length; i++)
            {
                var countOnes = 0;
                var countZeros = 0;

                foreach (var line in inputLines)
                {
                    var c = line.ToCharArray()[i];
                    switch (c)
                    {
                        case '0':
                            countZeros++;
                            break;
                        case '1':
                            countOnes++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                sb.Append(countZeros <= countOnes ? '0' : '1');
            }

            return sb.ToString();
        }

        public static string FindOxygenGeneratorRating_Part2(string[] inputLines)
        {
            var filteredList = inputLines.ToList();
            var step = 0;

            while (filteredList.Count > 1)
            {
                var countZeros = filteredList.Count(it => it.Substring(step, 1) == "0");
                var countOnes = filteredList.Count(it => it.Substring(step, 1) == "1");

                var filter = countOnes >= countZeros ? "1" : "0";
                
                filteredList = filteredList.Where(it => it.Substring(step, 1) == filter).ToList();

                step++;
            }
                
            return filteredList.First();
        }
        
        public static string FindCO2ScrubberRating_Part2(string[] inputLines)
        {
            var filteredList = inputLines.ToList();
            var step = 0;

            while (filteredList.Count > 1)
            {
                var countZeros = filteredList.Count(it => it.Substring(step, 1) == "0");
                var countOnes = filteredList.Count(it => it.Substring(step, 1) == "1");

                var filter = countZeros <= countOnes ? "0" : "1";
                
                filteredList = filteredList.Where(it => it.Substring(step, 1) == filter).ToList();

                step++;
            }
                
            return filteredList.First();
        }
        
        public static int GetIntFromBinary(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }
    }
}