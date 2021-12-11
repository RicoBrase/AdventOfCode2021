using System.Linq;
using AdventOfCode._2021.Day11;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day11;

public class Day11CommonTests
{

    private static readonly string[] InputSample = {
        "5483143223",
        "2745854711",
        "5264556173",
        "6141336146",
        "6357385478",
        "4167524645",
        "2176841721",
        "6882881134",
        "4846848554",
        "5283751526"
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
        // run twice, since first step is kind of lame and no flashes happen there
        Day11Common.RunSingleSimulationStepAndReturnCountOfFlashes(board);
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
        // run twice, since first step is kind of lame and no flashes happen there
        Day11Common.RunSingleSimulationStepAndReturnCountOfFlashes(actualBoard);
        var actualFlashes = Day11Common.RunSingleSimulationStepAndReturnCountOfFlashes(actualBoard);

        // assert
        actualFlashes.Should().Be(expectedFlashes);
    }
    
    [Fact]
    public void RunUntilFlashesSync_ShouldReturnCorrectNumberOfSimulationStepsNeeded()
    {
        // arrange
        const int expectedResult = 195;
        var board = Day11Common.ParseInput(InputSample);

        // act
        var actualResult = Day11Common.RunUntilFlashesSync(board);

        // assert
        actualResult.Should().Be(expectedResult);
    }

}