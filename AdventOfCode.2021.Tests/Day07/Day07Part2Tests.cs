using System.Collections.Generic;
using AdventOfCode._2021.Day07;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day07
{
    public class Day07Part2Tests
    {

        [Fact]
        public void GetLeastAmountOfFuelNeeded_ShouldReturnCorrectAmountOfFuel()
        {
            // arrange
            const int expectedAmountOfFuel = 168;
            var listOfCrabs = new List<int> {16, 1, 2, 0, 4, 2, 7, 1, 2, 14};

            // act
            var actualFuelAmount = Day07Common.GetLeastAmountOfFuelNeeded_Part2(listOfCrabs);

            // assert
            actualFuelAmount.Should().Be(expectedAmountOfFuel);

        }
        
    }
}