using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day12;

namespace AdventOfCode._2021.Day13;

public class TransparentPaper
{
    public List<List<bool>> Coordinates { get; private set; } = new();

    public TransparentPaper(List<Point> points)
    {
        Init(points);
    }

    private void Init(List<Point> points)
    {
        var maxX = points.Select(it => it.X).Max();
        var maxY = points.Select(it => it.Y).Max();
        
        for(var y = 0; y <= maxY; y++)
        {
            Coordinates.Add(new List<bool>());
            for (var x = 0; x <= maxX; x++)
            {
                Coordinates[y].Add(false);
            }
        }
        
        points.ForEach(p => Coordinates[p.Y][p.X] = true);
    }

    public void Fold(Fold fold)
    {
        var folded = new List<List<bool>>();
        
        switch (fold)
        {
            case {Direction: FoldDirection.XAxis}:
                for(var y = 0; y < Coordinates.Count; y++)
                {
                    folded.Add(new List<bool>());
                    for(var x = 0; x < fold.FoldLine; x++)
                    {
                        folded[y].Add(Coordinates[y][x] || Coordinates[y][fold.FoldLine + (fold.FoldLine - x)]);
                    }
                }

                break;
            case {Direction: FoldDirection.YAxis}:
                for(var y = 0; y < fold.FoldLine; y++)
                {
                    folded.Add(new List<bool>());
                    for(var x = 0; x < Coordinates[y].Count; x++)
                    {
                        folded[y].Add(Coordinates[y][x] || Coordinates[fold.FoldLine + (fold.FoldLine - y)][x]);
                    }
                }

                break;
        }
        
        Coordinates = folded;
    }
}