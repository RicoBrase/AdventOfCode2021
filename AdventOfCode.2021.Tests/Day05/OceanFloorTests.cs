using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day05;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day05
{
    public class OceanFloorTests
    {
        [Fact]
        public void Build_ShouldBuildArraysOfCorrectSize()
        {
            // arrange
            var lines = new List<Line>
            {
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 10, Y = 0}},
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 0, Y = 10}}
            };

            var oceanFloor = new OceanFloor();
            lines.ForEach(oceanFloor.AddLine);

            // act
            var result = oceanFloor.Build_Part1();

            // assert
            result.Should().HaveCount(11);
            result[0].Should().HaveCount(11);
        }
        
        [Fact]
        public void Build_Part1_ShouldBuildArraysWithCorrectValues()
        {
            // arrange
            var lines = new List<Line>
            {
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 10, Y = 0}},
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 0, Y = 10}}
            };

            var oceanFloor = new OceanFloor();
            lines.ForEach(oceanFloor.AddLine);

            // act
            var result = oceanFloor.Build_Part1();

            // assert
            result[0][0].Should().Be(2);
            result[0][1].Should().Be(1);
            result[1][0].Should().Be(1);
            result[1][1].Should().Be(0);
        }
        
        [Fact]
        public void Build_Part2_ShouldBuildArraysWithCorrectValues()
        {
            // arrange
            var lines = new List<Line>
            {
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 10, Y = 0}},
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 0, Y = 10}},
                new() { Start = new Point {X = 0, Y = 0}, End = new Point {X = 10, Y = 10}},
            };

            var oceanFloor = new OceanFloor();
            lines.ForEach(oceanFloor.AddLine);

            // act
            var result = oceanFloor.Build_Part2();

            // assert
            result[0][0].Should().Be(3);
            result[0][1].Should().Be(1);
            result[1][0].Should().Be(1);
            result[1][1].Should().Be(1);
        }
    }
}