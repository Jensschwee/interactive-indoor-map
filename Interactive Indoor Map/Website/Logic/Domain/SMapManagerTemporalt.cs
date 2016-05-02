using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;
using Website.Logic.Helpers;

namespace Website.Logic.Domain
{
    public class SMapManagerTemporalt
    {
        private CalcMinMaxMean calcMinMaxMean;
        private SMAP smapDal;
        public SMapManagerTemporalt(SMAP smapDal)
        {
            this.smapDal = smapDal;
            calcMinMaxMean = new CalcMinMaxMean();
        }

        public void TemporalTemperatureUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var floor in building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalTemperatureUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalTemperatureUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>())
            {
                TemporalTemperatureUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalTemperatureUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Temperature))
            {
                TemporalSummary temporalSummary =
                    calcMinMaxMean.CalcSMapMinMaxMean(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Temperature).Key,
                            timeFrom,
                            timeTo), timeFrom,
                        timeTo);
                room.AverageTemperature = temporalSummary.MeanValue;
                room.MinObservedTemperature = temporalSummary.MinValue;
                room.MaxObservedTemperature = temporalSummary.MaxValue;
            }
        }

        public void TemporalCO2Update(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var floor in building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalCO2Update(floor, timeFrom, timeTo);
            }
        }

        public void TemporalCO2Update(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>())
            {
                TemporalCO2Update(room, timeFrom, timeTo);
            }
        }

        public void TemporalCO2Update(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.CO2))
            {
                TemporalSummary temporalSummary =
                    calcMinMaxMean.CalcSMapMinMaxMean(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.CO2).Key, timeFrom,
                            timeTo), timeFrom,
                        timeTo);
                room.AverageCO2 = temporalSummary.MeanValue;
                room.MinObservedCO2 = temporalSummary.MinValue;
                room.MaxObservedCO2 = temporalSummary.MaxValue;
            }
        }

        public void TemporalOccupantsUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var floor in building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalOccupantsUpdate(floor, timeFrom, timeTo);
            }

            if (building.Endpoints != null && building.Endpoints.SmapEndponts.ContainsValue(SensorType.Occupants))
            {
                TemporalSummary temporalSummary =
                    calcMinMaxMean.CalcSMapMinMaxMean(
                        smapDal.GetHistoricSensorValue(
                            building.Endpoints.SmapEndponts.First(s => s.Value == SensorType.CO2).Key, timeFrom,
                            timeTo), timeFrom,
                        timeTo);
                building.AverageOccupants = temporalSummary.MeanValue;
                building.MinObservedOccupants = temporalSummary.MinValue;
                building.MaxObservedOccupants = temporalSummary.MaxValue;
            }
        }

        public void TemporalOccupantsUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>())
            {
                TemporalOccupantsUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalOccupantsUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Occupants))
            {
                TemporalSummary temporalSummary =
                    calcMinMaxMean.CalcSMapMinMaxMean(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Occupants).Key, timeFrom,
                            timeTo), timeFrom,
                        timeTo);
                room.AverageOccupants = temporalSummary.MeanValue;
                room.MinObservedOccupants = temporalSummary.MinValue;
                room.MaxObservedOccupants = temporalSummary.MaxValue;
            }
        }
        public void TemporalWifiClientUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var floor in building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalWifiClientUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalWifiClientUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                TemporalRoom room in
                    floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>())
            {
                TemporalWifiClientUpdate(room, timeFrom, timeTo);

            }
        }

        public void TemporalWifiClientUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints?.WifiEndpoint != null)
            {
                //room.WifiClients = (int)smapDal.GetCurrentSensorValue(room.Endpoints.WifiEndpoint);
            }
        }


        public void TemporalLightUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var floor in building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalLightUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalLightUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>())
            {
                TemporalLightUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalLightUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Light))
            {
                TemporalSummary temporalSummary =
                    calcMinMaxMean.CalcSMapMinMaxMean(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Light).Key, timeFrom,
                            timeTo), timeFrom,
                        timeTo);
                room.AverageLight = temporalSummary.MeanValue;
                room.MinObservedLight = temporalSummary.MinValue;
                room.MaxObservedLight = temporalSummary.MaxValue;
            }
        }


        public void TemporalLumenUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Lumen))
            {
                TemporalSummary temporalSummary =
                    calcMinMaxMean.CalcSMapMinMaxMean(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Lumen).Key, timeFrom,
                            timeTo), timeFrom,
                        timeTo);
                room.AverageLumen = temporalSummary.MeanValue;
                room.MinObservedLumen = temporalSummary.MinValue;
                room.MaxObservedLumen = temporalSummary.MaxValue;
            }
        }

        public void TemporalLumenUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>())
            {
                TemporalLumenUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalLumenUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalLumenUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalHotWaterUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalHotWaterUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalHotWaterUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null && floor.Endpoints.SmapEndponts.ContainsValue(SensorType.HotWater))
            {
                TemporalSummary temporalSummary =
                        calcMinMaxMean.CalcSMapMinMaxMean(
                            smapDal.GetHistoricSensorValue(
                                floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.HotWater).Key, timeFrom,
                                timeTo), timeFrom,
                            timeTo);
                floor.AverageHotWaterConsumption = temporalSummary.MeanValue;
                floor.MinObservedHotWaterConsumption = temporalSummary.MinValue;
                floor.MaxObservedHotWaterConsumption = temporalSummary.MaxValue;
            }
        }

        public void TemporalColdWaterUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalColdWaterUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalColdWaterUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null && floor.Endpoints.SmapEndponts.ContainsValue(SensorType.ColdWater))
            {
                TemporalSummary temporalSummary =
                        calcMinMaxMean.CalcSMapMinMaxMean(
                            smapDal.GetHistoricSensorValue(
                                floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.ColdWater).Key, timeFrom,
                                timeTo), timeFrom,
                            timeTo);
                floor.AverageColdWaterConsumption = temporalSummary.MeanValue;
                floor.MinObservedColdWaterConsumption = temporalSummary.MinValue;
                floor.MaxObservedColdWaterConsumption = temporalSummary.MaxValue;
            }
        }

        public void TemporalPowerConsumptionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null)
            {
                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.TotalPowerConsumption))
                {
                    //TemporalSummary temporalSummary =
                    //    calcMinMaxMean.CalcSMapMinMaxMean(
                    //        smapDal.GetHistoricSensorValue(
                    //            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.ColdWater).Key, timeFrom,
                    //            timeTo), timeFrom,
                    //        timeTo);
                    //floor.AverageColdWaterConsumption = temporalSummary.MeanValue;
                    //floor.MinObservedColdWaterConsumption = temporalSummary.MinValue;
                    //floor.MaxObservedColdWaterConsumption = temporalSummary.MaxValue;
                }

                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.HardwarePowerConsumption))
                {
                    //TemporalSummary temporalSummary =
                    //    calcMinMaxMean.CalcSMapMinMaxMean(
                    //        smapDal.GetHistoricSensorValue(
                    //            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.HardwarePowerConsumption).Key, timeFrom,
                    //            timeTo), timeFrom,
                    //        timeTo);
                    //floor.AverageHotWaterConsumption = temporalSummary.MeanValue;
                    //floor.MinObservedHotWaterConsumption = temporalSummary.MinValue;
                    //floor.MaxObservedHotWaterConsumption = temporalSummary.MaxValue;
                }

                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.LightPowerConsumption))
                {
                    //TemporalSummary temporalSummary =
                    //    calcMinMaxMean.CalcSMapMinMaxMean(
                    //        smapDal.GetHistoricSensorValue(
                    //            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.LightPowerConsumption).Key, timeFrom,
                    //            timeTo), timeFrom,
                    //        timeTo);
                    //floor.AverageHotWaterConsumption = temporalSummary.MeanValue;
                    //floor.MinObservedHotWaterConsumption = temporalSummary.MinValue;
                    //floor.MaxObservedHotWaterConsumption = temporalSummary.MaxValue;
                }

                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.OtherPowerConsumption))
                {
                    //TemporalSummary temporalSummary =
                    //    calcMinMaxMean.CalcSMapMinMaxMean(
                    //        smapDal.GetHistoricSensorValue(
                    //            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.OtherPowerConsumption).Key, timeFrom,
                    //            timeTo), timeFrom,
                    //        timeTo);
                    //floor.AverageHotWaterConsumption = temporalSummary.MeanValue;
                    //floor.MinObservedHotWaterConsumption = temporalSummary.MinValue;
                    //floor.MaxObservedHotWaterConsumption = temporalSummary.MaxValue;
                }

                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.VentilationPowerConsumption))
                {
                    //TemporalSummary temporalSummary =
                    //    calcMinMaxMean.CalcSMapMinMaxMean(
                    //        smapDal.GetHistoricSensorValue(
                    //            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.VentilationPowerConsumption).Key, timeFrom,
                    //            timeTo), timeFrom,
                    //        timeTo);
                    //floor.AverageHotWaterConsumption = temporalSummary.MeanValue;
                    //floor.MinObservedHotWaterConsumption = temporalSummary.MinValue;
                    //floor.MaxObservedHotWaterConsumption = temporalSummary.MaxValue;
                }
            }
        }
    }
}