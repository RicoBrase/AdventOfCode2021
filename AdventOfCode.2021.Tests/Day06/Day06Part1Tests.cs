using System.Linq;
using AdventOfCode._2021.Day06;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day06
{
    public class Day06Part1Tests
    {

        [Fact]
        public void ParseInput_ShouldReturnCorrectList()
        {
            // arrange
            const string input = "3,4,3,1,2";

            // act
            var actualList = Day06Common.ParseInput(input);

            // assert
            actualList.Should().HaveCount(5);
            actualList.First().Timer.Should().Be(3);
        }
        
        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        public void SimulateXDays_ShouldReturnCorrectList(int days, int expectedCountOfFish)
        {
            // arrange
            const string input = "3,4,3,1,2";
            var initialList = Day06Common.ParseInput(input);

            // act
            var listAfter18Days = Day06Common.SimulateXDays(initialList, days);

            // assert
            listAfter18Days.Should().HaveCount(expectedCountOfFish);
        }
        
    }
}