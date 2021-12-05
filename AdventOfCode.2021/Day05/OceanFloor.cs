using System;
using System.Collections.Generic;

namespace AdventOfCode._2021.Day05
{
    public class OceanFloor
    {
        public List<Line> Lines { get; } = new();

        public void AddLine(Line line)
        {
            Lines.Add(line);
        }

        public int[][] Build_Part1()
        {
            var maxX = 0;
            var maxY = 0;

            foreach (var line in Lines)
            {
                maxX = Max(Max(line.Start.X, line.End.X), maxX);
                maxY = Max(Max(line.Start.Y, line.End.Y), maxY);
            }

            var buildOceanFloor = new int[maxY+1][];

            for (var y = 0; y <= maxY; y++)
            {
                buildOceanFloor[y] = new int[maxX + 1];
            }
            
            foreach (var line in Lines)
            {
                foreach (var point in Day05Common.GetListOfPointsOfALine_Part1(line))
                {
                    buildOceanFloor[point.Y][point.X]++;
                }
            }

            return buildOceanFloor;
        }

        private int Max(int a, int b)
        {
            return Day05Common.Max(a, b);
        }
        
    }
}