using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2021.Day05
{
    public static class Day05Common
    {

        public static List<Point> GetListOfPointsOfALine_Part1(Line line)
        {
            var listOfPoints = new List<Point>();

            var xDiff = line.Start.X - line.End.X;
            var yDiff = line.Start.Y - line.End.Y;

            if (xDiff == 0)
            {
                listOfPoints.AddRange(GetRange_Part1(line.Start.Y, line.End.Y)
                    .Select(step => new Point {X = line.Start.X, Y = step}));
            }
            else if (yDiff == 0)
            {
                listOfPoints.AddRange(GetRange_Part1(line.Start.X, line.End.X)
                    .Select(step => new Point {X = step, Y = line.Start.Y}));
            }
            
            return listOfPoints;
        }
        
        public static List<Point> GetListOfPointsOfALine_Part2(Line line)
        {
            var listOfPoints = new List<Point>();

            var xDiff = line.Start.X - line.End.X;
            var yDiff = line.Start.Y - line.End.Y;

            if (xDiff == 0)
            {
                listOfPoints.AddRange(GetRange_Part1(line.Start.Y, line.End.Y)
                    .Select(step => new Point {X = line.Start.X, Y = step}));
            }
            else if (yDiff == 0)
            {
                listOfPoints.AddRange(GetRange_Part1(line.Start.X, line.End.X)
                    .Select(step => new Point {X = step, Y = line.Start.Y}));
            }
            else
            {
                var xStep = xDiff > 0 ? -1 : 1;
                var yStep = yDiff > 0 ? -1 : 1;

                var pointX = line.Start.X;
                var pointY = line.Start.Y;

                while (pointX != line.End.X + xStep && pointY != line.End.Y + yStep)
                {
                    listOfPoints.Add(new Point
                    {
                        X = pointX,
                        Y = pointY
                    });

                    pointX += xStep;
                    pointY += yStep;
                }
            }
            
            return listOfPoints;
        }

        public static List<int> GetRange_Part1(int start, int end)
        {
            var range = new List<int>();
            var step = Utils.Min(start, end);
            var target = Utils.Max(start, end);
            while (step <= target)
            {
                range.Add(step);
                step++;
            }
            
            return range;
        }

        public static List<Line> ParseInput(string[] input)
        {
            var listOfLines = new List<Line>();

            foreach (var inputLine in input)
            {
                var match = Regex.Match(inputLine, @"(?<startX>\d+),(?<startY>\d+)\s+->\s+(?<endX>\d+),(?<endY>\d+)");
                listOfLines.Add(
                new Line
                    {
                        Start = new Point
                        {
                            X = Convert.ToInt32(match.Groups["startX"].Value),
                            Y = Convert.ToInt32(match.Groups["startY"].Value)
                        },
                        End = new Point
                        {
                            X = Convert.ToInt32(match.Groups["endX"].Value),
                            Y = Convert.ToInt32(match.Groups["endY"].Value)
                        }
                    });
            }

            return listOfLines;
        }

    }
}