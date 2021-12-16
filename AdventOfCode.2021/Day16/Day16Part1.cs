using System;
using System.IO;

namespace AdventOfCode._2021.Day16;

public class Day16Part1 : IDay
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
        var sumOfAllPacketVersions = Day16Common.SumOfAllVersionNumbersOfPacket(rootPacket);
        
        Console.WriteLine($"Sum of all version numbers of all packets: {sumOfAllPacketVersions}");
    }
}