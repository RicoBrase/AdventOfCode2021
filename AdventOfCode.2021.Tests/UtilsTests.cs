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
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 10)]
        [InlineData(5, 15)]
        public void CalculatePartialSum(int nthWantedPartialSum, int expectedPartialSum)
        {
            // arrange
            
            // act
            var actualPartialSum = Utils.CalculatePartialSum(nthWantedPartialSum);

            // assert
            actualPartialSum.Should().Be(expectedPartialSum);
        }

        [Theory]
        [InlineData("hallo", "ahllo")]
        [InlineData("otto", "oott")]
        [InlineData("hello", "ehllo")]
        public void StringSort_ShouldCorrectlySortCharsOfString(string input, string expectedResult)
        {
            // arrange
            // act
            var actualResult = input.Sort();

            // assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}