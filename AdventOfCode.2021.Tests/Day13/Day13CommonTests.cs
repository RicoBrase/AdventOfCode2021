using AdventOfCode._2021.Day13;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day13;

public class Day13CommonTests
{

    private static readonly string[] Input =
    {
        "6,10",
        "0,14",
        "9,10",
        "0,3",
        "10,4",
        "4,11",
        "6,0",
        "6,12",
        "4,1",
        "0,13",
        "10,12",
        "3,4",
        "3,0",
        "8,4",
        "1,10",
        "2,14",
        "8,10",
        "9,0",
        "",
        "fold along y=7",
        "fold along x=5"
    };
    
    [Fact]
    public void ParseInput_ShouldReturnCorrectlyParsedData()
    {
        // arrange
        const int expectedWidth = 11;
        const int expectedHeight = 15;
        const int expectedFoldCounts = 2;
        
        // act
        var (paper, folds) = Day13Common.ParseInput(Input);

        // assert
        paper.Coordinates.Should().HaveCount(expectedHeight);
        foreach (var row in paper.Coordinates)
        {
            row.Should().HaveCount(expectedWidth); 
        }
        folds.Should().HaveCount(expectedFoldCounts);
    }
    
}