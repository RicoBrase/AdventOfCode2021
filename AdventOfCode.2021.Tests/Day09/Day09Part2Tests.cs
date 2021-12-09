using System.Collections.Generic;
using AdventOfCode._2021.Day09;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day09;

public class Day09Part2Tests
{
    private static readonly string[] InputLines =
    {
        "2199943210",
        "3987894921",
        "9856789892",
        "8767896789",
        "9899965678",
    };

    [Theory]
    [InlineData(0, 1, 1, 0)]
    [InlineData(0, 0, 1, 0)]
    [InlineData(1, 0, 1, 0)]
    [InlineData(5, 0, 9, 0)]
    [InlineData(6, 0, 9, 0)]
    [InlineData(6, 1, 9, 0)]
    public void GetLowPointFromPoint_ShouldReturnCorrectLowPoint(int posX, int posY, int lowPosX, int lowPosY)
    {
        // arrange
        var heightMap = Day09Common.ParseInputToHeightMap(InputLines);

        // act
        var (actualLowPointX, actualLowPointY) = Day09Common.GetLowPointFromPoint(heightMap, posX, posY);

        // assert
        actualLowPointX.Should().Be(lowPosX);
        actualLowPointY.Should().Be(lowPosY);
    }

    [Fact]
    public void GetAllBasins_ShouldReturnAllBasins()
    {
        // arrange
        var expectedResult = new Dictionary<(int x, int y), int>
        {
            {(1, 0), 3},
            {(9, 0), 9},
            {(2, 2), 14},
            {(6, 4), 9}
        };
        var heightMap = Day09Common.ParseInputToHeightMap(InputLines);

        // act
        var actualResult = Day09Common.GetAllBasins(heightMap);

        // assert
        foreach (var (resultKey, resultVal) in actualResult)
        {
            resultVal.Count.Should().Be(expectedResult[resultKey]);
        }
    }
    
    [Fact]
    public void GetSizesOfThreeBiggestBasins_ShouldReturnCorrectBasinSizes()
    {
        // arrange
        var expectedBasinSizes = new List<int> { 9, 9, 14 };
        var heightMap = Day09Common.ParseInputToHeightMap(InputLines);
        var allBasins = Day09Common.GetAllBasins(heightMap);
        
        // act
        var actualBiggestBasinSizes = Day09Common.GetSizesOfThreeBiggestBasins(allBasins);

        // assert
        actualBiggestBasinSizes.Should().BeEquivalentTo(expectedBasinSizes);
    }
}