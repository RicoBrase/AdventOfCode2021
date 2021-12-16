using System;
using System.IO;

namespace AdventOfCode._2021.Day16;

public class Day16Part2 : IDay
{
    private const string INPUT = "inputs/day16_input.txt";
        
    public void Run()
    {
        if (!File.Exists(INPUT))
        {
            Console.Error.WriteLine("Input not found");
            return;
        }

        var input = File.ReadAllText(INPUT);
        var binaryData = Day16Common.ParseInput(input);
        var rootPacket = Day16Common.ParseBinaryValuesToPacket(binaryData);

        Console.WriteLine($"Value of packet: {rootPacket.Value}");
    }
}