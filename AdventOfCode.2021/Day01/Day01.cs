using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public static class Day01
    {
        private const string INPUT_DAY01_1 = "inputs/day01_1_input.txt";
        
        public static void Main(string[] args)
        {
            if (!File.Exists(INPUT_DAY01_1))
            {
                Console.Error.WriteLine("Input not found");
                return;
            }

            var input_1 = File.ReadAllLines(INPUT_DAY01_1).Select(it => Convert.ToInt32(it)).ToList();
            var comparisons_1 = CompareDepthMeasurements(input_1);
            var countLargerMeasurements = HowManyMeasurementsAreLargerThanPreviousMeasurement(comparisons_1);
            
            Console.WriteLine($"There are {countLargerMeasurements} measurements, that are larger than the previous one.");
        }

        public static List<(int measurement, MeasurementComparison comparison)> CompareDepthMeasurements(List<int> measurements)
        {
            var comparisionList = new List<(int measurement, MeasurementComparison comparison)>();

            int? previousMeasurement = null;
            foreach (var measurement in measurements)
            {
                var comparision = MeasurementComparison.NoPreviousMeasurement;
                if (previousMeasurement is not null)
                {
                    if (measurement < previousMeasurement)
                    {
                        comparision = MeasurementComparison.Decreased;
                    }
                    else if (measurement > previousMeasurement)
                    {
                        comparision = MeasurementComparison.Increased;
                    }
                }

                previousMeasurement = measurement;
                comparisionList.Add((measurement, comparision));
            }

            return comparisionList;
        }
        
        public static int HowManyMeasurementsAreLargerThanPreviousMeasurement(
            List<(int measurement, MeasurementComparison comparison)> listOfComparisons
            )
        {
            if (listOfComparisons is null) throw new ArgumentNullException(nameof(listOfComparisons));
            
            return listOfComparisons.Count(it => it.comparison == MeasurementComparison.Increased);
        }
        
    }
}