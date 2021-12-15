using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day14;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode._2021.Tests.Day14;

public class Day14CommonTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    private static readonly string[] Input = {
        "NNCB",
        "",
        "CH -> B",
        "HH -> N",
        "CB -> H",
        "NH -> C",
        "HB -> C",
        "HC -> B",
        "HN -> C",
        "NN -> C",
        "BH -> H",
        "NC -> B",
        "NB -> B",
        "BN -> B",
        "BB -> N",
        "BC -> B",
        "CC -> N",
        "CN -> C"
    };

    public Day14CommonTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ParseInput_ShouldReturnCorrectlyParsedData()
    {
        // arrange
        var expectedPolymer = "NNCB".ToList();
        var expectedDictionary = new Dictionary<string, char>
        {
            {"CH", 'B'},
            {"HH", 'N'},
            {"CB", 'H'},
            {"NH", 'C'},
            {"HB", 'C'},
            {"HC", 'B'},
            {"HN", 'C'},
            {"NN", 'C'},
            {"BH", 'H'},
            {"NC", 'B'},
            {"NB", 'B'},
            {"BN", 'B'},
            {"BB", 'N'},
            {"BC", 'B'},
            {"CC", 'N'},
            {"CN", 'C'}
        };
        
        // act
        var (actualPolymer, actualInsertionRules) = Day14Common.ParseInput(Input);

        // assert
        actualPolymer.Should().BeEquivalentTo(expectedPolymer);
        actualInsertionRules.Should().BeEquivalentTo(expectedDictionary);
    }

    [Theory]
    [InlineData(1, "NCNBCHB")]
    [InlineData(2, "NBCCNBBBCBHCB")]
    [InlineData(3, "NBBBCNCCNBBNBNBBCHBHHBCHB")]
    [InlineData(4, "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")]
    public void RunPolymerizationStep_Part1_ShouldReturnCorrectPolymer(int stepsToRun, string expectedPolymer)
    {
        // arrange
        var (startingPolymer, insertionRules) = Day14Common.ParseInput(Input);

        // act
        var actualPolymer = startingPolymer;
        for (var i = 0; i < stepsToRun; i++)
        {
            actualPolymer = Day14Common.RunPolymerizationStep_Part1(actualPolymer, insertionRules);
        }

        // assert
        actualPolymer.Should().BeEquivalentTo(expectedPolymer);
    }
    
    [Theory]
    [InlineData(1, "NCNBCHB")]
    [InlineData(2, "NBCCNBBBCBHCB")]
    [InlineData(3, "NBBBCNCCNBBNBNBBCHBHHBCHB")]
    [InlineData(4, "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")]
    public void RunPolymerizationForXSteps_ShouldReturnCorrectGroupCounts(int stepsToRun, string expectedPolymer)
    {
        // arrange
        var expectedPolymerCounts = new Dictionary<string, long>();
        for (var i = 0; i < expectedPolymer.Length - 1; i++)
        {
            var group = expectedPolymer.Substring(i, 2);
            if(!expectedPolymerCounts.ContainsKey(group)) expectedPolymerCounts.Add(group, 0);

            expectedPolymerCounts[group]++;
        }

        var (startingPolymer, insertionRules) = Day14Common.ParseInput(Input);

        // act
        var actualPolymer = Day14Common.RunPolymerizationForXSteps(stepsToRun, string.Join("", startingPolymer), insertionRules);

        // assert
        actualPolymer.Should().BeEquivalentTo(expectedPolymerCounts);
    }

    [Theory]
    [InlineData(10, 1588L)]
    public void GetElementScore_Part1_ShouldReturnCorrectNumber_IfPolymerizationStep_Part1IsUsed(int stepsToRun, long expectedScore)
    {
        // arrange
        var (startingPolymer, insertionRules) = Day14Common.ParseInput(Input);
        var polymer = startingPolymer;
        for (var i = 0; i < stepsToRun; i++)
        {
            _testOutputHelper.WriteLine($"Step: {i}");
            polymer = Day14Common.RunPolymerizationStep_Part1(polymer, insertionRules);
        }
        
        // act
        var actualScore = Day14Common.GetElementScore(polymer);

        // assert
        actualScore.Should().Be(expectedScore);
    }
    
    [Theory]
    [InlineData(10, 1588L)]
    [InlineData(40, 2188189693529L)]
    public void GetElementScore_Part2_ShouldReturnCorrectNumber_IfRunPolymerizationForXStepsIsUsed(int stepsToRun, long expectedScore)
    {
        // arrange
        var (startingPolymer, insertionRules) = Day14Common.ParseInput(Input);
        var polymer = Day14Common.RunPolymerizationForXSteps(stepsToRun, string.Join("", startingPolymer), insertionRules);

        // act
        var actualScore = Day14Common.GetElementScore_Part2(string.Join("", startingPolymer), polymer);

        // assert
        actualScore.Should().Be(expectedScore);
    }
}