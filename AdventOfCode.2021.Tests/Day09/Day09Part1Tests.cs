using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day09;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day09;

public class Day09Part1Tests
{
    private static readonly string[] InputLines =
    {
        "2199943210",
        "3987894921",
        "9856789892",
        "8767896789",
        "9899965678",
    };
    
    [Fact]
    public void ParseInputToHeightMap_ShouldReturnCorrectData()
    {
        // arrange
        const int expectedHeightmapRows = 5;
        const int expectedHeightmapColumns = 10;

        // act
        var actualResult = Day09Common.ParseInputToHeightMap(InputLines);

        // assert
        actualResult.Should().HaveCount(expectedHeightmapRows);
        foreach (var actualRow in actualResult)
        {
            actualRow.Should().HaveCount(expectedHeightmapColumns);
        }
    }

    [Fact]
    public void TransformHeightDataToRiskLevel_ShouldReturnCorrectRiskLevels()
    {
        // arrange
        var lowPoints = new List<int> { 1, 0, 5, 5 };
        var expectedRiskLevels = new List<int> { 2, 1, 6, 6 };

        // act
        var actualRiskLevels = Day09Common.TransformHeightDataToRiskLevel(lowPoints);

        // assert
        actualRiskLevels.Should().BeEquivalentTo(expectedRiskLevels); 
    }
    
    [Fact]
    public void TransformHeightDataToRiskLevel_ShouldHaveCorrectSum()
    {
        // arrange
        var heightMap = Day09Common.ParseInputToHeightMap(InputLines);
        var lowPoints = Day09Common.GetAllLowPoints(heightMap);
        var riskLevels = Day09Common.TransformHeightDataToRiskLevel(lowPoints);

        const int expectedRiskLevelSum = 15;
        
        // act
        var actualRiskLevelSum = riskLevels.Sum();

        // assert
        actualRiskLevelSum.Should().Be(expectedRiskLevelSum);
    }

    [Theory]
    [InlineData(0, 0, false)]
    [InlineData(1, 0, true)]
    [InlineData(5, 0, false)]
    [InlineData(0, 1, false)]
    [InlineData(0, 4, false)]
    [InlineData(2, 2, true)]
    [InlineData(9, 0, true)]
    [InlineData(6, 4, true)]
    [InlineData(7, 4, false)]
    [InlineData(9, 4, false)]
    public void IsLowPoint_ShouldReturnTrue_IfPointIsLowPoint(int x, int y, bool expectedResult)
    {
        // arrange
        var heightMap = Day09Common.ParseInputToHeightMap(InputLines);
        
        // act
        var actualResult = Day09Common.IsLowPoint(heightMap, x, y);

        // assert
        actualResult.Should().Be(expectedResult);
    }

    [Fact]
    public void GetAllLowPoints_ShouldReturnAllLowPoints()
    {
        // arrange
        var expectedLowPoints = new List<int> { 1, 0, 5, 5 };
        var heightMap = Day09Common.ParseInputToHeightMap(InputLines);
        
        // act
        var actualLowPoints = Day09Common.GetAllLowPoints(heightMap);

        // assert
        actualLowPoints.Should().BeEquivalentTo(expectedLowPoints);
    }
}