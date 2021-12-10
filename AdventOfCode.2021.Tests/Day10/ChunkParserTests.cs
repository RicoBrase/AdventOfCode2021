using System.Linq;
using AdventOfCode._2021.Day10;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day10;

public class ChunkParserTests
{

    [Theory]
    // [InlineData("()", ErrorScore.IllegalParenthesisClose, ChunkParserState.CorruptedLine)]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", ErrorScore.Valid, ChunkParserState.IncompleteLine)]
    [InlineData("[(()[<>])]({[<{<<[]>>(", ErrorScore.Valid, ChunkParserState.IncompleteLine)]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", ErrorScore.IllegalBracesClose, ChunkParserState.CorruptedLine)]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", ErrorScore.Valid, ChunkParserState.IncompleteLine)]
    [InlineData("[[<[([]))<([[{}[[()]]]", ErrorScore.IllegalParenthesisClose, ChunkParserState.CorruptedLine)]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", ErrorScore.IllegalBracketsClose, ChunkParserState.CorruptedLine)]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", ErrorScore.Valid, ChunkParserState.IncompleteLine)]
    [InlineData("[<(<(<(<{}))><([]([]()", ErrorScore.IllegalParenthesisClose, ChunkParserState.CorruptedLine)]
    [InlineData("<{([([[(<>()){}]>(<<{{", ErrorScore.IllegalChevronsClose, ChunkParserState.CorruptedLine)]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", ErrorScore.Valid, ChunkParserState.IncompleteLine)]
    public void RunAndGetScore_ShouldReturnCorrectScore(string line, ErrorScore expectedScore, ChunkParserState expectedEndState)
    {
        // arrange
        var parser = new ChunkParser(line);

        // act
        var (actualScore, actualEndState) = parser.RunAndGetScore();

        // assert
        actualScore.Should().Be(expectedScore);
        actualEndState.Should().Be(expectedEndState);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
    [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
    public void RunAndGetAutocompleteChars_ShouldReturnCorrectListOfAutocompleteCharacters(string line, string expectedResult)
    {
        // arrange
        var parser = new ChunkParser(line);
        
        // act
        var actualResult = string.Join(
            "",
            parser
                .RunAndGetAutocompleteChars()
                .Select(it => ((char)it).ToString()));

        // assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
    
}