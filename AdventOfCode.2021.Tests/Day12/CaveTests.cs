using AdventOfCode._2021.Day12;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day12;

public class CaveTests
{
    [Theory]
    [InlineData("a", true)]
    [InlineData("A", false)]
    [InlineData("start", true)]
    [InlineData("end", true)]
    public void IsSmallCave_ShouldReturnTrue_IfCaveIsSmallCave(string caveName, bool expectedResult)
    {
        // arrange
        var cave = new Cave(caveName);
        
        // act
        var actualResult = cave.IsSmallCave;

        // assert
        actualResult.Should().Be(expectedResult);
    }
}