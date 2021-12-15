using AdventOfCode._2021.Day15;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day15;

public class Day15CommonTests
{
    private static readonly string[] Input =
    {
        "1163751742",
        "1381373672",
        "2136511328",
        "3694931569",
        "7463417111",
        "1319128137",
        "1359912421",
        "3125421639",
        "1293138521",
        "2311944581"
    };

    [Fact]
    public void ParseInput_ShouldReturnDatasetOfCorrectSize()
    {
        // arrange
        const int expectedWidth = 10;
        const int expectedHeight = 10;
        
        // act
        var (caveGraph, caveWidth, caveHeight) = Day15Common.ParseInput(Input);
        
        // assert
        caveGraph.Should().HaveCount(expectedHeight * expectedWidth);
        caveWidth.Should().Be(expectedWidth);
        caveHeight.Should().Be(expectedHeight);
    }
    
    [Fact]
    public void ParseInput_ShouldReturnDatasetOfCorrectSize_IfScaleFactorIsSupplied()
    {
        // arrange
        const int scaleFactor = 5;
        const int expectedWidth = 50;
        const int expectedHeight = 50;
        
        // act
        var (caveGraph, caveWidth, caveHeight) = Day15Common.ParseInput(Input, scaleFactor);
        
        // assert
        caveGraph.Should().HaveCount(expectedHeight * expectedWidth);
        caveWidth.Should().Be(expectedWidth);
        caveHeight.Should().Be(expectedHeight);
    }

    [Theory]
    [InlineData(0, 0, 1)]
    [InlineData(9, 9, 1)]
    [InlineData(4, 0, 7)]
    [InlineData(4, 3, 9)]
    [InlineData(0, 7, 3)]
    public void ParseInput_ShouldReturnDatasetWithCorrectValues(int x, int y, int expectedValue)
    {
        // arrange
        // act
        var (caveGraph, _, _) = Day15Common.ParseInput(Input);
        var actualFieldRisk = caveGraph[(x, y)].Risk;

        // assert
        actualFieldRisk.Should().Be(expectedValue);
    }
    
    [Theory]
    [InlineData(49, 49, 9)]
    [InlineData(48, 49, 7)]
    [InlineData(47, 49, 4)]
    [InlineData(9, 9, 1)]
    [InlineData(8, 9, 8)]
    [InlineData(7, 9, 5)]
    public void ParseInput_ShouldReturnDatasetWithCorrectValues_IfScaleFactorIsSupplied(int x, int y, int expectedValue)
    {
        // arrange
        const int scaleFactor = 5;
        
        // act
        var (caveGraph, _, _) = Day15Common.ParseInput(Input, scaleFactor);
        var sampleFieldRisk = caveGraph[(x, y)].Risk;

        // assert
        sampleFieldRisk.Should().Be(expectedValue);
    }
}