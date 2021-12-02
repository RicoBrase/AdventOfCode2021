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

            foreach (var (command, distance) in listOfCommands)
            {
                switch (command)
                {
                    case SubmarineCommands.Forward:
                        position += distance;
                        break;
                    case SubmarineCommands.Down:
                        depth += distance;
                        break;
                    case SubmarineCommands.Up:
                        depth -= distance;
                        break;
                }
            }
            
            return (position, depth);
        }
        
        public static (int horiontalPosition, int aim, int depth) CalculatePositionByCommandInput_Part2(
            List<(SubmarineCommands command, int distance)> listOfCommands)
        {
            var position = 0;
            var aim = 0;
            var depth = 0;

            foreach (var (command, distance) in listOfCommands)
            {
                switch (command)
                {
                    case SubmarineCommands.Forward:
                        position += distance;
                        depth += aim * distance;
                        break;
                    case SubmarineCommands.Down:
                        aim += distance;
                        break;
                    case SubmarineCommands.Up:
                        aim -= distance;
                        break;
                }
            }
            
            return (position, aim, depth);
        }

    }
}