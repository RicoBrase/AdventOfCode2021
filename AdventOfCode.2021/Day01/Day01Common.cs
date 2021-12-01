using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public static class Day01Common
    {
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

        public static List<int> TransformWithThreeMeasurementSlidingWindow(List<int> listOfMeasurements)
        {
            var summedMeasurements = new List<int>();
            var step = 0;

            while (step <= listOfMeasurements.Count - 3)
            {
                summedMeasurements.Add(listOfMeasurements.GetRange(step, 3).Sum());
                step++;
            }
            
            return summedMeasurements;
        }
    }
}