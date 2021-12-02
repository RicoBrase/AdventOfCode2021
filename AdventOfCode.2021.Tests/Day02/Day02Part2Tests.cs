using System.Collections.Generic;
using AdventOfCode._2021.Day02;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day02
{
    public class Day02Part2Tests
    {

        private static readonly string[] Input = {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        [Fact]
        public void CalculatePositionByCommandInput_ShouldStartAtPositionZeroZero()
        {
            // arrange

            // act
            var (horiontalPosition, aim, depth) = Day02Common.CalculatePositionByCommandInput_Part2(new List<(SubmarineCommands command, int distance)>());

            // assert
            horiontalPosition.Should().Be(0);
            aim.Should().Be(0);
            depth.Should().Be(0);
        }
        
        [Fact]
        public void CalculatePositionByCommandInput_ShouldReturnCorrectPosition()
        {
            // arrange
            const int expectedPosition = 15;
            const int expectedDepth = 60;
            var listOfCommands = Day02Common.GetListOfCommandsByProcessingInput(Input);

            // act
            var (actualPosition, _, actualDepth) = Day02Common.CalculatePositionByCommandInput_Part2(listOfCommands);

            // assert
            actualPosition.Should().Be(expectedPosition);
            actualDepth.Should().Be(expectedDepth);
        }

    }
}