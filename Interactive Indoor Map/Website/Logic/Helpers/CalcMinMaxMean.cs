using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.Logic.Helpers
{
    public class CalcMinMaxMean
    {
        private DateConverter dateConverter;
        public CalcMinMaxMean()
        {
            dateConverter = new DateConverter();
        }

        public TemporalSummary CalcSMapMinMaxMean(SMapSensorReading reading, DateTime? fromTime = null, DateTime? toTime = null)
        {
            TemporalSummary temporalSummary = new TemporalSummary
            {
                MinValue = double.MinValue,
                MaxValue = double.MaxValue,
                MeanValue = 0
            };
            TimeSpan? timeSpan = null;
            if (fromTime != null && toTime != null)
            {
                timeSpan = toTime - fromTime;
            }

            for (int i = 0; i < reading.Readings.Count; i++)
            {
                List<double> readings = reading.Readings[i];

                double readingsValue = readings[1];
                if (temporalSummary.MinValue > readingsValue)
                {
                    temporalSummary.MinValue = readingsValue;
                }
                else if (temporalSummary.MaxValue < readingsValue)
                {
                    temporalSummary.MaxValue = readingsValue;
                }

                if (timeSpan != null)
                {
                    DateTime time = dateConverter.ConvertDate((long) readings[0]);
                    TimeSpan? timeDif = null;
                    if (reading.Readings.Count == i)
                    {
                        timeDif = toTime - time;
                    }
                    else
                    {
                        timeDif = dateConverter.ConvertDate((long) reading.Readings[i + 1][0]) - time;
                    }

                    temporalSummary.MeanValue += readingsValue * (timeDif.Value.TotalSeconds / timeSpan.Value.TotalSeconds);
                }
                else
                {
                    temporalSummary.MeanValue += readingsValue / reading.Readings.Count;
                }

            }
            return temporalSummary;
        }

    }
}