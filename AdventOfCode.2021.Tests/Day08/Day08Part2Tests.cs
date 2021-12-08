using System.Collections.Generic;
using AdventOfCode._2021.Day08;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day08
{
    public class Day08Part2Tests
    {
        [Fact]
        public void BuildDictionaryForLine_ShouldReturnCorrectDictionaryForLine()
        {
            // arrange
            var input = new List<string>
            {
                "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab"
            };

            var expectedDict = new Dictionary<string, int>
            {
                {"abcdefg", 8},
                {"bcdef", 5},
                {"acdfg", 2},
                {"abcdf", 3},
                {"abd", 7},
                {"abcdef", 9},
                {"bcdefg", 6},
                {"abef", 4},
                {"abcdeg", 0},
                {"ab", 1}
            };

            // act
            var actualDict = Day08Common.BuildDictionaryForLine(input);

            // assert
            actualDict.Should().BeEquivalentTo(expectedDict);
        }
        
        [Theory]
        [InlineData("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", "8394")]
        [InlineData("edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", "9781")]
        [InlineData("fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", "1197")]
        [InlineData("fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb", "9361")]
        [InlineData("aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea", "4873")]
        [InlineData("fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb", "8418")]
        [InlineData("dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe", "4548")]
        [InlineData("bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef", "1625")]
        [InlineData("egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb", "8717")]
        [InlineData("gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce", "4315")]
        public void DecodeOutputValueDigitsWithDictionary_ShouldReturnCorrectOutput(string input, string expectedResult)
        {
            // arrange
            var (signalPatterns, outputValues) = Day08Common.ParseLine(input);
            var dict = Day08Common.BuildDictionaryForLine(signalPatterns);
            
            // act
            var actualResult = Day08Common.DecodeOutputValueDigitsWithDictionary(dict, outputValues);

            // assert
            actualResult.Should().Be(expectedResult);
        }

    }

}