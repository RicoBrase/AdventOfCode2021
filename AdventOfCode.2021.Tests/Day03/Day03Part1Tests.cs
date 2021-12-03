using System.Collections.Generic;
using AdventOfCode._2021.Day03;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day03
{
    public class Day03Part1Tests
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

        [Theory]
        [InlineData("101", 5)]
        [InlineData("10110", 22)]
        public void GetIntFromBinary_ShouldReturnCorrectInt(string input, int expectedResult) {
            // arrange
            
            // act
            var actualResult = Day03Common.GetIntFromBinary(input);

            // assert
            actualResult.Should().Be(expectedResult);
        }
        
        [Fact]
        public void GetGammaRateFromInput_ShouldReturnCorrectString()
        {
            // arrange
            const string expectedResult = "10110";

            // act
            var actualResult = Day03Common.GetGammaRateFromInput_Part1(_input);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public void GetEpsilonRateFromInput_ShouldReturnCorrectString()
        {
            // arrange
            const string expectedResult = "01001";

            // act
            var actualResult = Day03Common.GetEpsilonRateFromInput_Part1(_input);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        
    }
}