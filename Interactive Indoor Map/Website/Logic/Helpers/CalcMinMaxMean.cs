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

        public TemporalSummary CalcSMapMinMaxMeanHouerliy(List<SMapSensorReading> reading,DateTime fromTime, DateTime toTime)
        {
            TemporalSummary temporalSummary = new TemporalSummary
            {
                MinValue = double.MaxValue,
                MaxValue = double.MinValue,
                MeanValue = 0
            };
            TimeSpan timeSpan = toTime - fromTime;

            for (int i = 0; i < reading[0].Readings.Count - 1; i++)
            {
                List<double> readings1 = new List<double>();
                readings1.AddRange(reading[0].Readings[i]);

                List<double> readings2 =
                    new List<double>();
                readings2.AddRange(reading[0].Readings[i + 1]);

                for (int j = 1; j < reading.Count; j++)
                {
                    readings1[1] += reading[j].Readings[i][1];
                    readings2[1] += reading[j].Readings[i+1][1];
                }

                TimeSpan timeBetween = dateConverter.ConvertDate((long) reading[0].Readings[i+1][0]) - dateConverter.ConvertDate((long)reading[0].Readings[i][0]);

                double readingsValue = ((readings2[1] - readings1[1]) / timeBetween.TotalMinutes) * 60;

                if (temporalSummary.MinValue > readingsValue)
                {
                    temporalSummary.MinValue = readingsValue;
                }
                else if (temporalSummary.MaxValue < readingsValue)
                {
                    temporalSummary.MaxValue = readingsValue;
                }

                temporalSummary.MeanValue += (readingsValue * (timeBetween.TotalMinutes / timeSpan.TotalMinutes));

            }
            return temporalSummary;
        }

    }
}