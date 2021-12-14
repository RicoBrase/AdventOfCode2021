using System.Collections.Generic;
using AdventOfCode._2021.Day13;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day13;

public class TransparentPaperTests
{

    private static readonly List<Point> InputPoints = new()
    {
        new Point(6, 10),
        new Point(0, 14),
        new Point(9, 10),
        new Point(0, 3),
        new Point(10, 4),
        new Point(4, 11),
        new Point(6, 0),
        new Point(6, 12),
        new Point(4, 1),
        new Point(0, 13),
        new Point(10, 12),
        new Point(3, 4),
        new Point(3, 0),
        new Point(8, 4),
        new Point(1, 10),
        new Point(2, 14),
        new Point(8, 10),
        new Point(9, 0)
    };

    private static readonly List<Fold> InputFolds = new()
    {
        new Fold(7, FoldDirection.YAxis),
        new Fold(5, FoldDirection.XAxis)
    };

    [Fact]
    public void Ctor_ShouldInitializeCoordinatesCorrectly()
    {
        // arrange
        const int expectedWidth = 11;
        const int expectedHeight = 15;

        // act
        var actualCoordinates = new TransparentPaper(InputPoints).Coordinates;

        // assert
        actualCoordinates.Should().HaveCount(expectedHeight);
        foreach (var row in actualCoordinates)
        {
            row.Should().HaveCount(expectedWidth);
        }

        actualCoordinates[0][0].Should().BeFalse();
        actualCoordinates[7][3].Should().BeFalse();
        actualCoordinates[8][0].Should().BeFalse();
        actualCoordinates[14][10].Should().BeFalse();
        
        actualCoordinates[0][9].Should().BeTrue();
        actualCoordinates[10][8].Should().BeTrue();
        actualCoordinates[14][2].Should().BeTrue();
        actualCoordinates[10][1].Should().BeTrue();
    }

    [Fact]
    public void Fold_ShouldFoldPaperOnCorrectly()
    {
        // arrange
        var foldOne = new Fold(7, FoldDirection.YAxis);
        var foldTwo = new Fold(5, FoldDirection.XAxis);
        const int expectedWidth = 5;
        const int expectedHeight = 7;
        var paper = new TransparentPaper(InputPoints);

        // act
        paper.Fold(foldOne);
        paper.Fold(foldTwo);
        var foldedCoordinates = paper.Coordinates;
        
        // assert
        foldedCoordinates.Should().HaveCount(expectedHeight);
        foreach (var row in foldedCoordinates)
        {
            row.Should().HaveCount(expectedWidth);
        }

        foldedCoordinates[0][0].Should().BeTrue();
        foldedCoordinates[0][1].Should().BeTrue();
        foldedCoordinates[0][2].Should().BeTrue();
        foldedCoordinates[1][0].Should().BeTrue();
        foldedCoordinates[2][0].Should().BeTrue();
        foldedCoordinates[3][0].Should().BeTrue();
    }
    
}