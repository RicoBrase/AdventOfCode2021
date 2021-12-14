using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day13;

public static class Day13Common
{

    public static (TransparentPaper paper, List<Fold> folds) ParseInput(string[] lines)
    {
        var folds = new List<Fold>();
        var points = new List<Point>();
        
        foreach (var line in lines)
        {
            if(string.IsNullOrWhiteSpace(line)) continue;
            if (line.StartsWith("fold"))
            {
                var foldData = line
                    .Split(" ")
                    .Last()
                    .Split("=");

                var foldAxis = foldData[0] switch
                {
                    "x" => FoldDirection.XAxis,
                    "y" => FoldDirection.YAxis,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var foldLine = Convert.ToInt32(foldData[1]);
                
                folds.Add(new Fold(foldLine, foldAxis));
                continue;
            }

            var pointData = line
                .Split(",")
                .Select(it => Convert.ToInt32(it))
                .ToArray();
            
            points.Add(new Point(pointData[0], pointData[1]));
        }
        
        return (new TransparentPaper(points), folds);
    }
    
}