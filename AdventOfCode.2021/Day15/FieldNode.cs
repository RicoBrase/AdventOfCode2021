using System;

namespace AdventOfCode._2021.Day15;

public class FieldNode
{
    public int X { get; }
    public int Y { get; }
    public int Risk { get; }
    public int Distance { get; set; } = int.MaxValue;
    public bool Visited { get; set; }

    public FieldNode(int x, int y, int risk)
    {
        X = x;
        Y = y;
        Risk = risk;
    }

    public override bool Equals(object obj)
    {
        if (obj is FieldNode other) return X == other.X && Y == other.Y;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}