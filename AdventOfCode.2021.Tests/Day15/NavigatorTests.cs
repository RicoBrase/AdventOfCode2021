using AdventOfCode._2021.Day15;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day15;

public class NavigatorTests
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

    [Theory]
    [InlineData(1, 40)]
    [InlineData(5, 315)]
    public void FindPathWithLowestTotalRisk_ShouldReturnCorrectValue(int scale, int expectedRisk)
    {
        // arrange
        var (caveGraph, caveWidth, caveHeight) = Day15Common.ParseInput(Input, scale);

        // act
        var actualRisk = Navigator.FindPathWithLowestTotalRisk(caveGraph, caveWidth, caveHeight);

        // assert
        actualRisk.Should().Be(expectedRisk);
    }
}