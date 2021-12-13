using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day12;

public static class Day12Common
{

    public static (Dictionary<string, Cave> caves, List<CaveConnection> connections) ParseInput(string[] input)
    {
        var caves = new Dictionary<string, Cave>();
        var listOfConnections = new List<CaveConnection>();

        foreach (var line in input)
        {
            var cavesInLine = line.Split("-");
            var caveOne = new Cave(cavesInLine[0]);
            var caveTwo = new Cave(cavesInLine[1]);
            
            if(!caves.ContainsKey(cavesInLine[0])) caves.Add(cavesInLine[0], caveOne);
            if(!caves.ContainsKey(cavesInLine[1])) caves.Add(cavesInLine[1], caveTwo);
            
            caves[cavesInLine[0]].ConnectedCaves.Add(caveTwo);
            caves[cavesInLine[1]].ConnectedCaves.Add(caveOne);
            
            listOfConnections.Add(new CaveConnection {CaveOne = caveOne, CaveTwo = caveTwo});
        }
        
        return (caves, listOfConnections);
    }

    public static List<Stack<string>> GetPathsThroughSmallCavesOnlyOnce(Dictionary<string, Cave> caves, List<CaveConnection> connections)
    {
        var foundPaths = new List<Stack<string>>();

        var searchingPath = new Stack<string>();
        searchingPath.Push("start");
        
        FindAllPaths_Part1(caves, foundPaths, searchingPath, "start", "end");

        return foundPaths;
    }

    private static void FindAllPaths_Part1(Dictionary<string, Cave> caves, List<Stack<string>> foundPaths, Stack<string> searchingPath, string startname, string endName)
    {
        foreach (var cave in caves[startname].ConnectedCaves)
        {
            if (cave.Equals(caves[endName]))
            {
                var path = new Stack<string>();
                foreach (var c in searchingPath)
                {
                    path.Push(c);
                }
                path.Push(cave.Name);
                foundPaths.Add(path);
            }
            else if(!searchingPath.Contains(cave.Name) && cave.IsSmallCave || !cave.IsSmallCave)
            {
                searchingPath.Push(cave.Name);
                FindAllPaths_Part1(caves, foundPaths, searchingPath, cave.Name, endName);
                searchingPath.Pop();
            }
        }
    }
    
    public static List<Stack<string>> GetPathsThroughSmallCavesOnlyOnceAndASingleOneTwice(Dictionary<string, Cave> caves, List<CaveConnection> connections)
    {
        var foundPaths = new List<Stack<string>>();

        var searchingPath = new Stack<string>();
        searchingPath.Push("start");

        FindAllPaths_Part2(caves, foundPaths, searchingPath, "start", "end");

        return foundPaths;
    }
    
    private static void FindAllPaths_Part2(Dictionary<string, Cave> caves, List<Stack<string>> foundPaths, Stack<string> searchingPath, string startname, string endName)
    {
        foreach (var cave in caves[startname].ConnectedCaves)
        {
            if (cave.Equals(caves[endName]))
            {
                var path = new Stack<string>();
                foreach (var c in searchingPath)
                {
                    path.Push(c);
                }
                path.Push(cave.Name);
                foundPaths.Add(path);
            }
            else if(
                !cave.IsSmallCave
                || (searchingPath.GroupBy(it => it).Count(it => it.Count() > 1 && caves[it.Key].IsSmallCave) == 0
                    || !searchingPath.Contains(cave.Name))
                && !cave.Name.Equals("start")
                )
            {
                searchingPath.Push(cave.Name);
                FindAllPaths_Part2(caves, foundPaths, searchingPath, cave.Name, endName);
                searchingPath.Pop();
            }
        }
    }
    
}