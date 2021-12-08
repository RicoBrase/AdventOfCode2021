using AdventOfCode._2021.Day08;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day08
{
    public class Day08Part1Tests
    {
        private static readonly string[] SampleInput = {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        [Fact]
        public void ParseInput_ShouldReturnCorrectlyParsedData()
        {
            // arrange
            var countOfEntries = SampleInput.Length;
            const int countOfElementsInSignalPatterns = 10;
            const int countOfElementsInOutputValue = 4;

            // act
            var parsedData = Day08Common.ParseInput(SampleInput);

            // assert
            parsedData.Should().HaveCount(countOfEntries); 
            foreach (var (signalPatterns, outputValues) in parsedData)
            {
                signalPatterns.Should().HaveCount(countOfElementsInSignalPatterns);
                outputValues.Should().HaveCount(countOfElementsInOutputValue);
            }
        }

        [Fact]
        public void CountSimpleDigits_Part1_ShouldReturnCorrectCount()
        {
            // arrange
            const int expectedCount = 26;
            var inputData = Day08Common.ParseInput(SampleInput);
            
            // act
            var actualCount = Day08Common.CountSimpleDigits_Part1(inputData);
            
            // assert
            actualCount.Should().Be(expectedCount);
        }

    }

}