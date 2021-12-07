using AdventOfCode._2021.Day06;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day06
{
    public class Day06Part2Tests
    {

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        [InlineData(256, 26984457539)]
        public void SimulateXDays_Part2_ShouldReturnCorrectList(int days, long expectedCountOfFish)
        {
            // arrange
            const string input = "3,4,3,1,2";
            var initialList = Day06Common.ParseInput(input);

            // act
            var qtyAfterXDays = Day06Common.SimulateXDays_Part2(initialList, days);

            // assert
            qtyAfterXDays.Should().Be(expectedCountOfFish);
        }
        
    }
}