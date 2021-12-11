using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day11;

public static class Day11Common
{
    public static List<List<Octopus>> ParseInput(string[] input)
    {
        return input
            .Select(line => line
                .Trim()
                .ToCharArray()
                .Select(it => it.ToString())
                .Select(byte.Parse)
                .Select(it => new Octopus { EnergyLevel = it, HasFlashed = false})
                .ToList()
            )
            .ToList();
    }

    public static int RunSingleSimulationStepAndReturnCountOfFlashes(List<List<Octopus>> boardOfOctopuses)
    {
        var flashes = 0;
        
        for (var y = 0; y < boardOfOctopuses.Count; y++)
        {
            for (var x = 0; x < boardOfOctopuses[y].Count; x++)
            {
                var octopus = boardOfOctopuses[y][x];
                octopus.EnergyLevel++;
                octopus.HasFlashed = false;
                boardOfOctopuses[y][x] = octopus;
            }
        }

        while (boardOfOctopuses.SelectMany(it => it).Any(it => it.EnergyLevel > 9 && !it.HasFlashed))
        {
            for (var y = 0; y < boardOfOctopuses.Count; y++)
            {
                for (var x = 0; x < boardOfOctopuses[y].Count; x++)
                {
                    var octopus = boardOfOctopuses[y][x];
                    if (octopus.EnergyLevel <= 9 || octopus.HasFlashed) continue;
                    // Flash; only if EnergyLevel > 9 and octopus hasn't flashed already
                    flashes++;
                    octopus.HasFlashed = true;
                    octopus.EnergyLevel = 0;
                    boardOfOctopuses[y][x] = octopus;
                    
                    // top
                    if (y > 0)
                    {
                        var top = boardOfOctopuses[y - 1][x];
                        top.EnergyLevel++;
                        boardOfOctopuses[y-1][x] = top;
                        
                        // top left
                        if (x > 0)
                        {
                            var topLeft = boardOfOctopuses[y - 1][x - 1];
                            topLeft.EnergyLevel++;
                            boardOfOctopuses[y-1][x-1] = topLeft;
                        }
                        
                        // top right
                        if (x < boardOfOctopuses[y - 1].Count - 1)
                        {
                            var topRight = boardOfOctopuses[y - 1][x + 1];
                            topRight.EnergyLevel++;
                            boardOfOctopuses[y - 1][x + 1] = topRight;
                        }
                    }
                    
                    // bottom
                    if (y < boardOfOctopuses.Count - 1)
                    {
                        var bottom = boardOfOctopuses[y + 1][x];
                        bottom.EnergyLevel++;
                        boardOfOctopuses[y+1][x] = bottom;
                        
                        // bottom left
                        if (x > 0)
                        {
                            var bottomLeft = boardOfOctopuses[y + 1][x - 1];
                            bottomLeft.EnergyLevel++;
                            boardOfOctopuses[y+1][x-1] = bottomLeft;
                        }
                        
                        // bottom right
                        if (x < boardOfOctopuses[y + 1].Count - 1)
                        {
                            var bottomRight = boardOfOctopuses[y + 1][x + 1];
                            bottomRight.EnergyLevel++;
                            boardOfOctopuses[y+1][x+1] = bottomRight;
                        }
                    }
                    
                    // left
                    if (x > 0)
                    {
                        var left = boardOfOctopuses[y][x - 1];
                        left.EnergyLevel++;
                        boardOfOctopuses[y][x-1] = left;
                    }
                    
                    // right
                    if (x < boardOfOctopuses[y].Count - 1)
                    {
                        var right = boardOfOctopuses[y][x + 1];
                        right.EnergyLevel++;
                        boardOfOctopuses[y][x+1] = right;
                    }
                }
            }
        }
        
        for (var y = 0; y < boardOfOctopuses.Count; y++)
        {
            for (var x = 0; x < boardOfOctopuses[y].Count; x++)
            {
                var octopus = boardOfOctopuses[y][x];
                if (octopus.HasFlashed)
                {
                    octopus.EnergyLevel = 0;
                    octopus.HasFlashed = false;
                    boardOfOctopuses[y][x] = octopus;
                }
            }
        }

        return flashes;
    }

    public static int RunUntilFlashesSync(List<List<Octopus>> boardOfOctopuses)
    {
        var countOfStepsRequired = 0;

        while (boardOfOctopuses.SelectMany(it => it).Any(it => it.EnergyLevel != 0))
        {
            RunSingleSimulationStepAndReturnCountOfFlashes(boardOfOctopuses);
            countOfStepsRequired++;
        }

        return countOfStepsRequired;
    }
}