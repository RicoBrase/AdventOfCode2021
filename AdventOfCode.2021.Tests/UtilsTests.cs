using System.Collections;
using System.Collections.Generic;
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

        [Theory]
        [InlineData(new[] {9, 14, 9}, 1134)]
        [InlineData(new[] {1, 2, 3}, 6)]
        [InlineData(new[] {2, 3, 4}, 24)]
        [InlineData(new[] {2, 3, 0}, 0)]
        public void Multiply_ShouldCorrectlyMultiplyTheNumbers(int[] factors, int expectedProduct)
        {
            // arrange
            // act
            var actualProduct = factors.Multiply();

            // assert
            actualProduct.Should().Be(expectedProduct);
        }

        [Theory]
        [InlineData(new[] {3, 2, 4, 1, 5}, 3)]
        [InlineData(new[] {1, 2, 3}, 2)]
        [InlineData(new[] {3, 2, 4, 1, 5, 7, 6}, 4)]
        public void Middle_ShouldReturnMiddleValueOfList(int[] list, int expectedResult)
        {
            // arrange
            // act
            var actualResult = list.Middle();

            // assert
            actualResult.Should().Be(expectedResult);
        }
    }
}