using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day15;

public static class Day15Common
{
    public static (Dictionary<(int x, int y), FieldNode> caveGraph, int caveWidth, int caveHeight) ParseInput(string[] input)
    {
        var graph = new Dictionary<(int x, int y), FieldNode>();

        for (var y = 0; y < input.Length; y++)
        {
            var rowFields = input[y].ToCharArray().Select(it => (int)char.GetNumericValue(it)).ToList();

            for (var x = 0; x < rowFields.Count; x++)
            {
                graph.Add((x, y), new FieldNode(x, y, rowFields[x]));
            }
        }
        
        return (graph, input[0].ToCharArray().Length, input.Length);
    }
    
    public static (Dictionary<(int x, int y), FieldNode> caveGraph, int caveWidth, int caveHeight) ParseInput(string[] input, int scale)
    {
        var graph = new Dictionary<(int x, int y), FieldNode>();
        var caveWidth = input[0].ToCharArray().Length;
        var caveHeight = input.Length;

        for (var scaleStepY = 0; scaleStepY < scale; scaleStepY++)
        {
            for (var scaleStepX = 0; scaleStepX < scale; scaleStepX++)
            {
                for (var y = 0; y < input.Length; y++)
                {
                    var rowFields = input[y]
                        .ToCharArray()
                        .Select(it => (int) char.GetNumericValue(it))
                        .ToList();

                    for (var x = 0; x < rowFields.Count; x++)
                    {
                        var fieldVal = rowFields[x] + scaleStepX + scaleStepY;
                        while (fieldVal > 9)
                        {
                            fieldVal -= 9;
                        }
                        graph.Add(
                            (x + caveWidth * scaleStepX, y + caveHeight * scaleStepY),
                            new FieldNode(
                                x + caveWidth * scaleStepX, 
                                y + caveHeight * scaleStepY,
                                fieldVal
                                )
                        );
                    }
                }
            }
        }

        return (graph, caveWidth * scale, caveHeight * scale);
    }
}