using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day16.Packets;

namespace AdventOfCode._2021.Day16;

public static class Day16Common
{
    public static List<BinaryValue> ParseInput(string input)
    {
        var listOfValues = new List<BinaryValue>();

        foreach (var c in input)
        {
            listOfValues.AddRange(TransformHexadecimalCharacterToBinaryValues(c));
        }

        return listOfValues;
    }

    public static Packet ParseBinaryValuesToPacket(List<BinaryValue> binaryData)
    {
        var packetBitLength = 6;
        var packetVersion = binaryData.Take(3).TransformBinaryValuesToInteger();
        var packetType = binaryData.Skip(3).Take(3).TransformBinaryValuesToInteger();
        long packetValue = 0;
        var childPackets = new List<Packet>();

        switch (packetType)
        {
            case PacketType.LITERAL_VALUE:
                var dataCursor = 6;
                var packetValueData = new List<BinaryValue>();
                var currentData = binaryData.Skip(dataCursor).Take(5).ToList();

                while (currentData.First() == BinaryValue.One)
                {
                    packetValueData.AddRange(currentData.Skip(1));
                    dataCursor += 5;
                    currentData = binaryData.Skip(dataCursor).Take(5).ToList();
                }

                packetBitLength = dataCursor + 5;
                packetValueData.AddRange(currentData.Skip(1));
                packetValue = packetValueData.TransformBinaryValuesToInteger();

                break;
            
            default:
                var lengthTypeId = binaryData.Skip(6).Take(1).TransformBinaryValuesToInteger();
                packetBitLength += 1;
                
                var currentReadBits = 0;
                switch (lengthTypeId)
                {
                    case LengthTypeId.TOTAL_LENGTH_IN_BITS:
                        var subpacketsLength = binaryData.Skip(7).Take(15).TransformBinaryValuesToInteger();
                        packetBitLength += 15;
                        
                        
                        while (currentReadBits < subpacketsLength)
                        {
                            var subpacket =
                                ParseBinaryValuesToPacket(binaryData.Skip(22 + currentReadBits).ToList());
                            currentReadBits += subpacket.BitLength;
                            childPackets.Add(subpacket);
                        }

                        packetBitLength += currentReadBits;
                        break;
                    case LengthTypeId.NUMBER_OF_SUB_PACKETS:
                        var subpacketsCount = binaryData.Skip(7).Take(11).TransformBinaryValuesToInteger();
                        packetBitLength += 11;
                        
                        var currentReadCount = 0;
                        while (currentReadCount < subpacketsCount)
                        {
                            var subpacket =
                                ParseBinaryValuesToPacket(binaryData.Skip(18 + currentReadBits).ToList());
                            currentReadCount++;
                            currentReadBits += subpacket.BitLength;
                            childPackets.Add(subpacket);
                        }

                        packetBitLength += currentReadBits;
                        
                        break;
                }
                break;
        }

        var packet = new Packet {Version = packetVersion, PacketType = packetType, Value = packetValue, BitLength = packetBitLength};
        
        if(childPackets.Count > 0) packet.ChildPackets.AddRange(childPackets);
        
        packet.Value = CalculateValue(packet);
        
        return packet;
    }

    public static long SumOfAllVersionNumbersOfPacket(Packet packet)
    {
        var sumOfVersionNumbers = packet.Version;

        foreach (var childPacket in packet.ChildPackets)
        {
            sumOfVersionNumbers += SumOfAllVersionNumbersOfPacket(childPacket);
        }

        return sumOfVersionNumbers;
    }

    private static long CalculateValue(Packet packet)
    {
        foreach (var childPacket in packet.ChildPackets)
        {
            childPacket.Value = CalculateValue(childPacket);
        }
        
        if(packet.PacketType == PacketType.LITERAL_VALUE) return packet.Value; 
        
        switch (packet.PacketType)
        {
            case PacketType.SUM:
                return packet.ChildPackets.Sum(it => it.Value);
            case PacketType.PRODUCT:
                return packet.ChildPackets.Select(it => it.Value).Aggregate((p1, p2) => p1*p2);
            case PacketType.MINIMUM:
                return packet.ChildPackets.Select(it => it.Value).Min();
            case PacketType.MAXIMUM:
                return packet.ChildPackets.Select(it => it.Value).Max();
            case PacketType.GREATER_THAN:
                return packet.ChildPackets.First().Value > packet.ChildPackets.Last().Value ? 1 : 0;
            case PacketType.LESS_THAN:
                return packet.ChildPackets.First().Value < packet.ChildPackets.Last().Value ? 1 : 0;
            case PacketType.EQUAL_TO:
                return packet.ChildPackets.First().Value == packet.ChildPackets.Last().Value ? 1 : 0;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static List<BinaryValue> TransformHexadecimalCharacterToBinaryValues(char c)
    {
        return c switch
        {
            '0' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.Zero, BinaryValue.Zero, BinaryValue.Zero },
            '1' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.Zero, BinaryValue.Zero, BinaryValue.One },
            '2' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.Zero, BinaryValue.One, BinaryValue.Zero },
            '3' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.Zero, BinaryValue.One, BinaryValue.One },
            '4' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.One, BinaryValue.Zero, BinaryValue.Zero },
            '5' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.One, BinaryValue.Zero, BinaryValue.One },
            '6' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.One, BinaryValue.One, BinaryValue.Zero },
            '7' => new List<BinaryValue> { BinaryValue.Zero, BinaryValue.One, BinaryValue.One, BinaryValue.One },
            '8' => new List<BinaryValue> { BinaryValue.One, BinaryValue.Zero, BinaryValue.Zero, BinaryValue.Zero },
            '9' => new List<BinaryValue> { BinaryValue.One, BinaryValue.Zero, BinaryValue.Zero, BinaryValue.One },
            'A' => new List<BinaryValue> { BinaryValue.One, BinaryValue.Zero, BinaryValue.One, BinaryValue.Zero },
            'B' => new List<BinaryValue> { BinaryValue.One, BinaryValue.Zero, BinaryValue.One, BinaryValue.One },
            'C' => new List<BinaryValue> { BinaryValue.One, BinaryValue.One, BinaryValue.Zero, BinaryValue.Zero },
            'D' => new List<BinaryValue> { BinaryValue.One, BinaryValue.One, BinaryValue.Zero, BinaryValue.One },
            'E' => new List<BinaryValue> { BinaryValue.One, BinaryValue.One, BinaryValue.One, BinaryValue.Zero },
            'F' => new List<BinaryValue> { BinaryValue.One, BinaryValue.One, BinaryValue.One, BinaryValue.One },
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }

    private static long TransformBinaryValuesToInteger(this IEnumerable<BinaryValue> binaryValues)
    {
        return Convert.ToInt64(
            string.Join(
                "",
                binaryValues
                    .Select(it => it switch
                    {
                        BinaryValue.Zero => '0',
                        BinaryValue.One => '1',
                        _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
                    })
                ),
            2);
    }
}