using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day16;
using AdventOfCode._2021.Day16.Packets;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day16;

public class Day16CommonTests
{

    [Theory]
    [InlineData("D2FE28", "110100101111111000101000")]
    [InlineData("38006F45291200", "00111000000000000110111101000101001010010001001000000000")]
    [InlineData("EE00D40C823060", "11101110000000001101010000001100100000100011000001100000")]
    public void ParseInput_ShouldReturnCorrectData(string input, string expectedResult)
    {
        // arrange
        // act
        var actualResult = Day16Common.ParseInput(input);
        var transformedResult = string.Join(
            "",
            actualResult
                .Select(it => it switch
                    {
                        BinaryValue.Zero => '0',
                        BinaryValue.One => '1',
                        _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
                    })
                .ToList());

        // assert
        transformedResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void ParseBinaryValuesToPacket_ShouldReturnCorrectPacket_IfLiteralValue()
    {
        // arrange
        const int expectedPacketVersion = 6;
        const int expectedPacketType = PacketType.LITERAL_VALUE;
        const int expectedPacketValue = 2021;
        const int expectedPacketBitLength = 21;
        const string input = "D2FE28";

        var binaryData = Day16Common.ParseInput(input);

        // act
        var packet = Day16Common.ParseBinaryValuesToPacket(binaryData);

        // assert
        packet.Version.Should().Be(expectedPacketVersion);
        packet.PacketType.Should().Be(expectedPacketType);
        packet.Value.Should().Be(expectedPacketValue);
        packet.ChildPackets.Should().BeEmpty();
        packet.BitLength.Should().Be(expectedPacketBitLength);
    }
    
    [Fact]
    public void ParseBinaryValuesToPacket_ShouldReturnCorrectPacket_IfOperatorPacketAndLengthTypeId0()
    {
        // arrange
        const int expectedPacketVersion = 1;
        const int expectedPacketType = 6;
        const int expectedPacketBitLength = 49;
        const string input = "38006F45291200";

        var expectedChildPackets = new List<Packet>
        {
            new() {Version = 6, PacketType = PacketType.LITERAL_VALUE, Value = 10},
            new() {Version = 2, PacketType = PacketType.LITERAL_VALUE, Value = 20}
        };

        var binaryData = Day16Common.ParseInput(input);

        // act
        var packet = Day16Common.ParseBinaryValuesToPacket(binaryData);

        // assert
        packet.Version.Should().Be(expectedPacketVersion);
        packet.PacketType.Should().Be(expectedPacketType);
        packet.ChildPackets.Should().BeEquivalentTo(expectedChildPackets);
        packet.BitLength.Should().Be(expectedPacketBitLength);
    }
    
    [Fact]
    public void ParseBinaryValuesToPacket_ShouldReturnCorrectPacket_IfOperatorPacketAndLengthTypeId1()
    {
        // arrange
        const int expectedPacketVersion = 7;
        const int expectedPacketType = 3;
        const int expectedPacketBitLength = 51;
        const string input = "EE00D40C823060";

        var expectedChildPackets = new List<Packet>
        {
            new() {Version = 2, PacketType = PacketType.LITERAL_VALUE, Value = 1},
            new() {Version = 4, PacketType = PacketType.LITERAL_VALUE, Value = 2},
            new() {Version = 1, PacketType = PacketType.LITERAL_VALUE, Value = 3}
        };

        var binaryData = Day16Common.ParseInput(input);

        // act
        var packet = Day16Common.ParseBinaryValuesToPacket(binaryData);

        // assert
        packet.Version.Should().Be(expectedPacketVersion);
        packet.PacketType.Should().Be(expectedPacketType);
        packet.ChildPackets.Should().BeEquivalentTo(expectedChildPackets);
        packet.BitLength.Should().Be(expectedPacketBitLength);
    }
    
    [Theory]
    [InlineData("C200B40A82", 3)]
    [InlineData("04005AC33890", 54)]
    [InlineData("880086C3E88112", 7)]
    [InlineData("CE00C43D881120", 9)]
    [InlineData("D8005AC2A8F0", 1)]
    [InlineData("F600BC2D8F", 0)]
    [InlineData("9C005AC2F8F0", 0)]
    [InlineData("9C0141080250320F1802104A08", 1)]
    public void ParseBinaryValuesToPacket_ShouldSetValueOfPacketCorrectly(string input, long expectedValue)
    {
        // arrange
        var binaryData = Day16Common.ParseInput(input);

        // act
        var packet = Day16Common.ParseBinaryValuesToPacket(binaryData);
 
        // assert
        packet.Value.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("8A004A801A8002F478", 16)]
    [InlineData("620080001611562C8802118E34", 12)]
    [InlineData("C0015000016115A2E0802F182340", 23)]
    [InlineData("A0016C880162017C3686B18A3D4780", 31)]
    public void SumOfAllVersionNumbersOfPacket_ShouldReturnCorrectValue(string input, int expectedSum)
    {
        // arrange
        var binaryData = Day16Common.ParseInput(input);
        var packet = Day16Common.ParseBinaryValuesToPacket(binaryData);

        // act
        var actualSum = Day16Common.SumOfAllVersionNumbersOfPacket(packet);

        // assert
        actualSum.Should().Be(expectedSum);
    }
    
}