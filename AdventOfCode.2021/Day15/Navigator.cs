using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day15;

public static class Navigator
{

    public static int FindPathWithLowestTotalRisk(Dictionary<(int x, int y), FieldNode> caveGraph, int caveWidth, int caveHeight)
    {
        return Dijkstra(caveGraph, caveGraph[(caveWidth - 1, caveHeight - 1)]);
    }

    private static int Dijkstra(IReadOnlyDictionary<(int x, int y), FieldNode> caveGraph, FieldNode target)
    {
        var q = new PriorityQueue<FieldNode, int>();
        caveGraph[(0, 0)].Distance = 0;
        q.Enqueue(caveGraph[(0,0)], 0);

        while (q.Count > 0)
        {
            var currentField = q.Dequeue();
            if(currentField.Visited) continue;
            
            currentField.Visited = true;
            if (currentField.Equals(target))
            {
                return target.Distance;
            }

            foreach (var surrounding in GetSurrounding(caveGraph, currentField))
            {
                var surroundingDistance = currentField.Distance + surrounding.Risk;
                if (surroundingDistance < surrounding.Distance) surrounding.Distance = surroundingDistance;
                if (surrounding.Distance!= int.MaxValue) q.Enqueue(surrounding, surrounding.Distance);
            }
        }
        
        return target.Distance;
    }

    private static List<FieldNode> GetSurrounding(IReadOnlyDictionary<(int x, int y), FieldNode> caveGraph, FieldNode node)
    {
        var surrounding = new List<FieldNode>();

        if(caveGraph.ContainsKey((node.X - 1, node.Y))) surrounding.Add(caveGraph[(node.X - 1, node.Y)]);
        if(caveGraph.ContainsKey((node.X + 1, node.Y))) surrounding.Add(caveGraph[(node.X + 1, node.Y)]);
        if(caveGraph.ContainsKey((node.X, node.Y - 1))) surrounding.Add(caveGraph[(node.X, node.Y - 1)]);
        if(caveGraph.ContainsKey((node.X, node.Y + 1))) surrounding.Add(caveGraph[(node.X, node.Y + 1)]);
        
        return surrounding.Where(it => !it.Visited).ToList();
    }

}