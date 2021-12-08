using System;

namespace AdventOfCode._2021
{
    public static class Utils
    {
        
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
        
        public static int CalculatePartialSum(int n)
        {
            return n * (n + 1) / 2;
        }

        public static string Sort(this string text)
        {
            var chars = text.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

    }
}