using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day02
{
    public static class Day02Common
    {

        public static List<(SubmarineCommands command, int distance)> GetListOfCommandsByProcessingInput(string[] input)
        {
            var listOfCommands = new List<(SubmarineCommands command, int distance)>();

            listOfCommands.AddRange(
                input.Select(it =>
                {
                    var lineContent = it.Split(' ');
                    var command = lineContent[0] switch
                    {
                        "forward" => SubmarineCommands.Forward,
                        "down" => SubmarineCommands.Down,
                        "up" => SubmarineCommands.Up,
                        _ => SubmarineCommands.Forward
                    };

                    var distance = Convert.ToInt32(lineContent[1]);

                    return (command, distance);
                })
            );
            
            return listOfCommands;
        }
        
        public static (int horiontalPosition, int depth) CalculatePositionByCommandInput_Part1(
            List<(SubmarineCommands command, int distance)> listOfCommands)
        {
            var position = 0;
            var depth = 0;

            foreach (var commandEntry in listOfCommands)
            {
                switch (commandEntry.command)
                {
                    case SubmarineCommands.Forward:
                        position += commandEntry.distance;
                        break;
                    case SubmarineCommands.Down:
                        depth += commandEntry.distance;
                        break;
                    case SubmarineCommands.Up:
                        depth -= commandEntry.distance;
                        break;
                }
            }
            
            return (position, depth);
        }
        
        

    }
}