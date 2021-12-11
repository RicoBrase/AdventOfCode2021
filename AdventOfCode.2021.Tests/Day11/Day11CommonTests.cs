using System.Linq;
using AdventOfCode._2021.Day11;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day11;

public class Day11CommonTests
{

    private static readonly string[] InputSample = new[]
    {
        "6594254334",
        "3856965822",
        "6375667284",
        "7252447257",
        "7468496589",
        "5278635756",
        "3287952832",
        "7993992245",
        "5957959665",
        "6394862637"
    };

    [Fact]
    public void ParseInput_ShouldReturnCorrectCountOfElements()
    {
        // arrange
        const int expectedWidth = 10;
        const int expectedHeight = 10;

        // act
        var actualResult = Day11Common.ParseInput(InputSample);

        // assert
        actualResult.Should().HaveCount(expectedHeight);
        actualResult.ForEach(row => row.Should().HaveCount(expectedWidth));
    }
    
    [Fact]
    public void RunSingleSimulationStep_ShouldReachCorrectBoardState()
    {
        // arrange
        var expectedBoard = Day11Common.ParseInput(new[]
        {
            "8807476555",
            "5089087054",
            "8597889608",
            "8485769600",
            "8700908800",
            "6600088989",
            "6800005943",
            "0000007456",
            "9000000876",
            "8700006848"
        })
            .Select(row => row
                .Select(it => it.EnergyLevel)
                .ToList())
            .ToList();
        var board = Day11Common.ParseInput(InputSample);

        // act
        Day11Common.RunSingleSimulationStepAndReturnCountOfFlashes(board);

        // assert
        var actualBoard = board.Select(row => row
                .Select(it => it.EnergyLevel)
                .ToList()
            )
            .ToList();
        actualBoard.Should().BeEquivalentTo(expectedBoard);
    }
    
    [Fact]
    public void RunSingleSimulationStep_ShouldReturnCorrectNumberOfFlashes()
    {
        // arrange
        const int expectedFlashes = 35;
        var actualBoard = Day11Common.ParseInput(InputSample);

        // act
        var actualFlashes = Day11Common.RunSingleSimulationStepAndReturnCountOfFlashes(actualBoard);

        // assert
        actualFlashes.Should().Be(expectedFlashes);
    }

}