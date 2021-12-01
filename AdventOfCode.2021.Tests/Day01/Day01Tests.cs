using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Tests.Day01
{
    public class Day01Tests
    {
        private readonly List<(int measurement, MeasurementComparison comparison)> _input = new()
        {
            (199, MeasurementComparison.NoPreviousMeasurement),
            (200, MeasurementComparison.Increased),
            (208, MeasurementComparison.Increased),
            (210, MeasurementComparison.Increased),
            (200, MeasurementComparison.Decreased),
            (207, MeasurementComparison.Increased),
            (240, MeasurementComparison.Increased),
            (269, MeasurementComparison.Increased),
            (260, MeasurementComparison.Decreased),
            (263, MeasurementComparison.Increased)
        };

        [Fact]
        public void CompareDepthMeasurements_ShouldResultInCorrectComparisions()
        {
            // arrange
            var measurements = _input.Select(it => it.measurement).ToList();

            // act
            var actualComparisons = _2021.Day01.Day01.CompareDepthMeasurements(measurements);

            // assert
            actualComparisons.Should().BeEquivalentTo(_input);
        }

        [Fact]
        public void HowManyMeasurementsAreLargerThanPreviousMeasurement_ShouldReturnCorrectNumber()
        {
            // arrange
            const int expectedResult = 7;

            // act
            var actualResult = _2021.Day01.Day01.HowManyMeasurementsAreLargerThanPreviousMeasurement(_input);

            // assert
            actualResult.Should().Be(expectedResult);
        }
}
}