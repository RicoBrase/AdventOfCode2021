using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day12;

public readonly struct Cave
{
    public string Name { get; }
    public bool IsSmallCave => Name.All(char.IsLower);
    public List<Cave> ConnectedCaves { get; } = new();

    public Cave(string name)
    {
        Name = name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Cave cave)
        {
            return Name.Equals(cave.Name);
        }
        
        return false;
    }
}