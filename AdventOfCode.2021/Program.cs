namespace AdventOfCode._2021
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            // RunDay<Day01Part1>();
        }

        private static void RunDay<TDay>() where TDay : IDay, new()
        {
            new TDay().Run();
        }
        
    }
}