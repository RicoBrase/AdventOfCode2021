using AdventOfCode._2021.Day03;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day03
{
    public class Day03Part2Tests
    {

        private readonly string[] _input = {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [Fact]
        public void FindOxygenGeneratorRating_ShouldReturnCorrectString()
        {
            // arrange
            const string expectedResult = "10111";

            // act
            var actualResult = Day03Common.FindOxygenGeneratorRating_Part2(_input);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public void FindCO2ScrubberRating_ShouldReturnCorrectString()
        {
            // arrange
            const string expectedResult = "01010";

            // act
            var actualResult = Day03Common.FindCO2ScrubberRating_Part2(_input);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

    }
}