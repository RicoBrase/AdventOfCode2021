using AdventOfCode._2021.Day05;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests
{
    public class UtilsTests
    {
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        [InlineData(1, 1, 1)]
        public void Max_ShouldReturnMaximum(int a, int b, int expected)
        {
            // arrange
            // act
            var actualResult = Utils.Max(a, b);

            // assert
            actualResult.Should().Be(expected);
        }
        
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 1)]
        [InlineData(1, 1, 1)]
        public void Min_ShouldReturnMinimum(int a, int b, int expected)
        {
            // arrange
            // act
            var actualResult = Utils.Min(a, b);

            // assert
            actualResult.Should().Be(expected);
        }
    }
}