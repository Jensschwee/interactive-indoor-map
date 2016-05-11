using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.Logic.Helpers
{
    public class CalculateTemporalSummary
    {
        private DateConverter dateConverter;

        public CalculateTemporalSummary()
        {
            dateConverter = new DateConverter();
        }

        public TemporalSummary CalcValues(SMapSensorReading reading)
        {
            TemporalSummary temporalSummary = new TemporalSummary
            {
                MinValue = double.MaxValue,
                MaxValue = double.MinValue,
                MeanValue = 0
            };
            if (reading.Readings.Count > 1)
            {
                SetMinMaxMeanValues(reading, temporalSummary);
            }
            else if (reading.Readings.Count == 1)
            {
                SetSingleMinMaxMeanValues(reading, temporalSummary);
            }
            else
            {
                temporalSummary.MaxValue = 0;
                temporalSummary.MinValue = 0;
            }
            return temporalSummary;
        }

        private static void SetSingleMinMaxMeanValues(SMapSensorReading reading, TemporalSummary temporalSummary)
        {
            double readingsValue = reading.Readings[0][0];
            temporalSummary.MinValue = readingsValue;

            temporalSummary.MaxValue = readingsValue;
            temporalSummary.MeanValue = readingsValue;
        }

        private void SetMinMaxMeanValues(SMapSensorReading reading, TemporalSummary temporalSummary)
        {
            DateTime fromTime = dateConverter.ConvertDate((long) reading.Readings[0][0]);
            DateTime toTime = dateConverter.ConvertDate((long) reading.Readings[reading.Readings.Count - 1][0]);
            TimeSpan timeSpan = toTime - fromTime;

            for (int i = 0; i < reading.Readings.Count - 1; i++)
            {
                List<double> readings = new List<double>();
                readings.AddRange(reading.Readings[i]);

                double readingsValue = readings[1];
                SetMinAndMaxValues(temporalSummary, readingsValue);

                DateTime time = dateConverter.ConvertDate((long) readings[0]);
                TimeSpan? timeDif = dateConverter.ConvertDate((long) reading.Readings[i + 1][0]) - time;
                temporalSummary.MeanValue += readingsValue*(timeDif.Value.TotalSeconds/timeSpan.TotalSeconds);
            }
        }

        public TemporalSummary CalcSMapMinMaxMeanHourly(List<SMapSensorReading> reading)
        {
            TemporalSummary temporalSummary = new TemporalSummary
            {
                MinValue = double.MaxValue,
                MaxValue = double.MinValue,
                MeanValue = 0
            };
            TimeSpan? timeSpan = null;

            if (reading[0].Readings.Count > 1)
            {
                DateTime timeFrom = dateConverter.ConvertDate((long)reading[0].Readings[1][0]);
                DateTime timeTo = dateConverter.ConvertDate((long)reading[0].Readings[reading[0].Readings.Count - 1][0]);
                timeSpan = timeTo - timeFrom;

                List<double> readings1 = new List<double>();
                readings1.AddRange(reading[0].Readings[0]);
                List<double> readings2 = new List<double>();
                readings2.AddRange(reading[0].Readings[reading[0].Readings.Count - 1]);

                for (int j = 1; j < reading.Count; j++)
                {
                    readings1[1] += reading[j].Readings[0][1];
                    readings2[1] += reading[j].Readings[reading[j].Readings.Count - 1][1];
                }

                temporalSummary.MeanValue = (readings2[1] - readings1[1]) / (timeSpan.Value.TotalHours);

                for (int i = 0; i < reading[0].Readings.Count - 1; i++)
                {
                    readings1 = new List<double>();
                    readings1.AddRange(reading[0].Readings[i]);
                    readings2 = new List<double>();
                    readings2.AddRange(reading[0].Readings[i + 1]);

                    for (int j = 1; j < reading.Count - 1; j++)
                    {
                        readings1[1] += reading[j].Readings[i][1];
                        readings2[1] += reading[j].Readings[i + 1][1];
                    }

                    timeTo = dateConverter.ConvertDate((long)reading[0].Readings[i + 1][0]);
                    timeFrom = dateConverter.ConvertDate((long)reading[0].Readings[i][0]);

                    TimeSpan timeBetween = timeTo - timeFrom;

                    double readingsValue = ((readings2[1] - readings1[1]) / timeBetween.TotalMinutes) * 60;

                    SetMinAndMaxValues(temporalSummary, readingsValue);
                }
            }
            return temporalSummary;
        }

        private static void SetMinAndMaxValues(TemporalSummary temporalSummary, double readingsValue)
        {
            if (temporalSummary.MinValue > readingsValue)
            {
                temporalSummary.MinValue = readingsValue;
            }

            if (temporalSummary.MaxValue < readingsValue)
            {
                temporalSummary.MaxValue = readingsValue;
            }
        }

        public TemporalSummary CalcBooleanEventbasedValues(SMapSensorReading reading, DateTime timeFrom, DateTime timeTo)
        {
            TemporalSummary temporalSummary = new TemporalSummary
            {
                MinValue = double.MaxValue,
                MaxValue = double.MinValue,
                MeanValue = 0
            };
            if (reading.Readings.Count > 1)
            {
                temporalSummary.MaxValue = 1;
                temporalSummary.MinValue = 0;
                TimeSpan timeSpan = timeTo - timeFrom;
                for (int i = 0; i < reading.Readings.Count - 1; i++)
                {
                    DateTime timeCurrent = dateConverter.ConvertDate((long)reading.Readings[i][0]);
                    double state = reading.Readings[i][1];

                    if (i + 1 > reading.Readings.Count)
                    {
                        TimeSpan timeBeetween = timeTo - timeCurrent;
                        temporalSummary.MeanValue += state * (timeBeetween.TotalSeconds / timeSpan.TotalSeconds);
                    }
                    else if (i != 0)
                    {
                        DateTime timeNext = dateConverter.ConvertDate((long)reading.Readings[i + 1][0]);
                        TimeSpan timeBeetween = timeNext - timeCurrent;
                        temporalSummary.MeanValue += state * (timeBeetween.TotalSeconds / timeSpan.TotalSeconds);
                    }
                    else //i = 0
                    {
                        DateTime timeNext = dateConverter.ConvertDate((long)reading.Readings[i + 1][0]);
                        //if state = 0, then all values before was 1
                        if (state.Equals(0.0))
                        {
                            TimeSpan timeFromStart = timeCurrent - timeFrom;
                            temporalSummary.MeanValue += 1 * (timeFromStart.TotalSeconds / timeSpan.TotalSeconds);
                        }
                        else
                        {
                            TimeSpan timeBeetween = timeNext - timeCurrent;
                            temporalSummary.MeanValue += state * (timeBeetween.TotalSeconds / timeSpan.TotalSeconds);
                        }
                    }
                }
            }
            else if (reading.Readings.Count == 1)
            {
                SetSingleCaseValue(reading, timeFrom, timeTo, temporalSummary);
            }
            else
            {
                temporalSummary.MaxValue = 0;
                temporalSummary.MinValue = 0;
            }
            return temporalSummary;
        }

        private void SetSingleCaseValue(SMapSensorReading reading, DateTime timeFrom, DateTime timeTo,
            TemporalSummary temporalSummary)
        {
            TimeSpan timeSpan = timeTo - timeFrom;
            double state = reading.Readings[0][1];
            DateTime time = dateConverter.ConvertDate((long)reading.Readings[0][0]);

            temporalSummary.MaxValue = 1;
            temporalSummary.MinValue = 0;

            TimeSpan timeFromStart = time - timeFrom;
            TimeSpan timeToEnd = timeTo - time;

            if (state.Equals(0.0))
            {
                temporalSummary.MeanValue = 1 * (timeFromStart.TotalSeconds / timeSpan.TotalSeconds);
            }

            temporalSummary.MeanValue += state * (timeToEnd.TotalSeconds / timeSpan.TotalSeconds);
        }
    }
}