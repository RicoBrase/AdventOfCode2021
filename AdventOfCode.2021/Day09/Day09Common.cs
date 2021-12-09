using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day09;

public static class Day09Common
{

    public static List<List<int>> ParseInputToHeightMap(string[] inputLines)
    {
        return inputLines
            .Select(line => line
                .Trim()
                .ToCharArray()
                .Select(it => Convert.ToInt32(it.ToString()))
                .ToList())
            .ToList();
    }

    public static List<(int height, int x, int y)> GetAllLowPoints(List<List<int>> heightMap)
    {
        var listOfLowPoints = new List<(int height, int x, int y)>();

        for (var y = 0; y < heightMap.Count; y++)
        {
            for (var x = 0; x < heightMap[y].Count; x++)
            {
                if(IsLowPoint(heightMap, x, y)) listOfLowPoints.Add((heightMap[y][x], x, y));
            }
        }
        
        return listOfLowPoints;
    }

    public static bool IsLowPoint(List<List<int>> heightMap, int x, int y)
    {
        var currentPoint = heightMap[y][x];
        
        // check above, only if not first row
        if (y > 0)
        {
            if (heightMap[y - 1][x] <= currentPoint) return false;
        }
        
        // check below, only if not last row
        if (y < heightMap.Count - 1)
        {
            if (heightMap[y + 1][x] <= currentPoint) return false;
        }

        // check left, only if not first column
        if (x > 0)
        {
            if (heightMap[y][x - 1] <= currentPoint) return false;
        }

        // check right, only if not last column
        if (x < heightMap[y].Count - 1)
        {
            if (heightMap[y][x + 1] <= currentPoint) return false;
        }

        return true;
    }

    public static List<int> TransformHeightDataToRiskLevel(List<int> heightData)
    {
        return heightData.Select(it => it + 1).ToList();
    }
    
}