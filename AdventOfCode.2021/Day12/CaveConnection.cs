namespace AdventOfCode._2021.Day12;

public struct CaveConnection
{
    public Cave CaveOne { get; init; }
    public Cave CaveTwo { get; init; }

    public bool HasCave(string name)
    {
        return CaveOne.Name.Equals(name) || CaveTwo.Name.Equals(name);
    }
}