using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2021.Day10;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day10;

public class Day10Part2Tests
{
    [Theory]
    [InlineData("}}]])})]", 288957)]
    [InlineData(")}>]})", 5566)]
    [InlineData("}}>}>))))", 1480781)]
    [InlineData("]]}}]}]}>", 995444)]
    [InlineData("])}>", 294)]
    public void GetAutocompleteScore_ShouldReturnCorrectScore(string autocomplete, int expectedScore)
    {
        // arrange
        var inputChars = autocomplete.ToCharArray()
            .Select(it => it switch
            {
                ')' => ChunkInputCharacter.ParenthesesClose,
                ']' => ChunkInputCharacter.BracketsClose,
                '}' => ChunkInputCharacter.BracesClose,
                '>' => ChunkInputCharacter.ChevronsClose,
                _ => throw new ArgumentOutOfRangeException()
            })
            .ToList();

        // act
        var actualScore = Day10Part2.GetAutocompleteScore(inputChars);

        // assert
        actualScore.Should().Be(expectedScore);
    }

    [Fact]
    public void GetAutocompleteScores_ShouldReturnCorrectScores()
    {
        // arrange
        var expectedResult = new List<int>
        {
            294, 5566, 288957, 995444, 1480781
        };
        var input = new[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };

        // act
        var actualResult = Day10Part2.GetAutocompleteScores(input);

        // assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public void MiddleScore_ShouldbeTheCorrectValue()
    {
        // arrange
        const int expectedResult = 288957;
        var input = new[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]",
        };

        // act
        var actualResult = Day10Part2.GetAutocompleteScores(input).Middle();

        // assert
        actualResult.Should().Be(expectedResult);
    }

}