using System.Collections.Generic;
using AdventOfCode._2021.Day02;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day02
{
    public class Day02Part1Tests
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
        public void GetListOfCommandsByProcessingInput_ShouldReturnCorrectList()
        {
            // arrange
            var expectedResult = new List<(SubmarineCommands command, int distance)>
            {
                (SubmarineCommands.Forward, 5),
                (SubmarineCommands.Down, 5),
                (SubmarineCommands.Forward, 8),
                (SubmarineCommands.Up, 3),
                (SubmarineCommands.Down, 8),
                (SubmarineCommands.Forward, 2)
            };

            // act
            var actualResult = Day02Common.GetListOfCommandsByProcessingInput(Input);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void CalculatePositionByCommandInput_ShouldStartAtPositionZeroZero()
        {
            // arrange

            // act
            var (horiontalPosition, depth) = Day02Common.CalculatePositionByCommandInput_Part1(new List<(SubmarineCommands command, int distance)>());

            // assert
            horiontalPosition.Should().Be(0);
            depth.Should().Be(0);
        }
        
        [Fact]
        public void CalculatePositionByCommandInput_ShouldReturnCorrectPosition()
        {
            // arrange
            const int expectedPosition = 15;
            const int expectedDepth = 10;
            var listOfCommands = Day02Common.GetListOfCommandsByProcessingInput(Input);

            // act
            var (actualPosition, actualDepth) = Day02Common.CalculatePositionByCommandInput_Part1(listOfCommands);

            // assert
            actualPosition.Should().Be(expectedPosition);
            actualDepth.Should().Be(expectedDepth);
        }

    }
}