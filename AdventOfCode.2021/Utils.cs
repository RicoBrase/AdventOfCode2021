using System;
using System.Collections.Generic;
using System.Linq;

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

        public static int Multiply(this IList<int> list)
        {
            var product = list.First();

            foreach (var i in list.Skip(1))
            {
                product *= i;
            }
            
            return product;
        }
        
        public static TValue Middle<TValue>(this IList<TValue> list)
        {
            var data = list
                .OrderBy(it => it)
                .ToList();

            var middleIndex = data.Count / 2;
            return data[middleIndex];
        }

    }
}