using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day01;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day01
{
    public class Day01Part2Tests
    {
        private readonly List<int> _input = new()
        {
            199, 200, 208, 210, 200, 207, 240, 269, 260, 263
        };

        [Fact]
        public void TransformWithThreeMeasurementSlidingWindow_ShouldReturnTheCorrectlyTransformedOutput()
        {
            // arrange
            var expectedResult = new List<int> {607, 618, 618, 617, 647, 716, 769, 792};
            
            // act
            var actualResult = Day01Common.TransformWithThreeMeasurementSlidingWindow(_input);

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

    }
}