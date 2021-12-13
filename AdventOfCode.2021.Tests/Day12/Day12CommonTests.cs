using System.Collections.Generic;
using AdventOfCode._2021.Day12;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day12;

public class Day12CommonTests
{
    private static readonly string[] Input =
    {
        "start-A",
        "start-b",
        "A-c",
        "A-b",
        "b-d",
        "A-end",
        "b-end"
    };
    
    [Fact]
    public void ParseInput_ShouldReturnCorrectData()
    {
        // arrange
        var caves = new Dictionary<string, Cave>
        {
            {"start", new Cave("start")},
            {"end", new Cave("end")},
            {"A", new Cave("A")},
            {"b", new Cave("b")},
            {"c", new Cave("c")},
            {"d", new Cave("d")}
        };
        var expectedResult = new List<CaveConnection>
        {
            new() {CaveOne = caves["start"], CaveTwo = caves["A"]},
            new() {CaveOne = caves["start"], CaveTwo = caves["b"]},
            new() {CaveOne = caves["A"], CaveTwo = caves["c"]},
            new() {CaveOne = caves["A"], CaveTwo = caves["b"]},
            new() {CaveOne = caves["b"], CaveTwo = caves["d"]},
            new() {CaveOne = caves["A"], CaveTwo = caves["end"]},
            new() {CaveOne = caves["b"], CaveTwo = caves["end"]}
        };

        // act
        var (_,actualResult) = Day12Common.ParseInput(Input);

        // assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [InlineData(new[]{"start-A", "start-b", "A-c", "A-b", "b-d", "A-end", "b-end"}, 10)]
    [InlineData(new[]{"dc-end","HN-start","start-kj","dc-start","dc-HN","LN-dc","HN-end","kj-sa","kj-HN","kj-dc"}, 19)]
    [InlineData(new[]{"fs-end","he-DX","fs-he","start-DX","pj-DX","end-zg","zg-sl","zg-pj","pj-he","RW-he","fs-DX","pj-RW","zg-RW","start-pj","he-WI","zg-he","pj-fs","start-RW"}, 226)]
    public void GetPathsThroughSmallCavesOnlyOnce_ShouldReturnCorrectPaths(string[] input, int expectedCountOfPaths)
    {
        // arrange
        var (caves, caveConnections) = Day12Common.ParseInput(input);

        // act
        var actualResult = Day12Common.GetPathsThroughSmallCavesOnlyOnce(caves, caveConnections);

        // assert
        actualResult.Should().HaveCount(expectedCountOfPaths);
    }
    
    [Theory]
    [InlineData(new[]{"start-A", "start-b", "A-c", "A-b", "b-d", "A-end", "b-end"}, 36)]
    [InlineData(new[]{"dc-end","HN-start","start-kj","dc-start","dc-HN","LN-dc","HN-end","kj-sa","kj-HN","kj-dc"}, 103)]
    [InlineData(new[]{"fs-end","he-DX","fs-he","start-DX","pj-DX","end-zg","zg-sl","zg-pj","pj-he","RW-he","fs-DX","pj-RW","zg-RW","start-pj","he-WI","zg-he","pj-fs","start-RW"}, 3509)]
    public void GetPathsThroughSmallCavesOnlyOnceAndASingleOneTwice_ShouldReturnCorrectPaths(string[] input, int expectedCountOfPaths)
    {
        // arrange
        var (caves, caveConnections) = Day12Common.ParseInput(input);

        // act
        var actualResult = Day12Common.GetPathsThroughSmallCavesOnlyOnceAndASingleOneTwice(caves, caveConnections);

        // assert
        actualResult.Should().HaveCount(expectedCountOfPaths);
    }
}