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
        
    }
}