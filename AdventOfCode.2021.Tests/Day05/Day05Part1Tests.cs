using AdventOfCode._2021.Day05;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day05
{
    public class Day05Part1Tests
    {
        [Theory]
        [InlineData(0, 3, new [] {0, 1, 2, 3})]
        [InlineData(4, 1, new [] {4, 3, 2, 1})]
        public void GetRange_Part1_ShouldReturnCorrectRange(int start, int end, int[] expectedRange)
        {
            // arrange

            // act
            var actualRange = Day05Common.GetRange_Part1(start, end);

            // assert
            actualRange.Should().BeEquivalentTo(expectedRange);
        }
        
        
    }
}