using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021.Day01
{
    public class Day01Common
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
    }
}