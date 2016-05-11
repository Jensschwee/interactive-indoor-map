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
    public class TemporalSMapManager
    {
        private CalculateTemporalSummary calculateTemporalSummary;
        private SMAP smapDal;

        public TemporalSMapManager(SMAP smapDal)
        {
            this.smapDal = smapDal;
            calculateTemporalSummary = new CalculateTemporalSummary();
        }

        public void TemporalUpdateAll(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            TemporalTemperatureUpdate(building, timeFrom, timeTo);
            TemporalCO2Update(building, timeFrom, timeTo);
            TemporalMotionDetectionUpdate(building, timeFrom, timeTo);
            TemporalLuxUpdate(building, timeFrom, timeTo);
            TemporalLightUpdate(building, timeFrom, timeTo);
            TemporalLightUpdate(building, timeFrom, timeTo);
            TemporalWifiClientUpdate(building, timeFrom, timeTo);
            TemporalOccupantsUpdate(building, timeFrom, timeTo);
            TemporalColdWaterUpdate(building, timeFrom, timeTo);
            TemporalHotWaterUpdate(building, timeFrom, timeTo);
            TemporalVentilationPowerConsumptionUpdate(building, timeFrom, timeTo);
            TemporalHardwarePowerConsumptionUpdate(building, timeFrom, timeTo);
            TemporalLightPowerConsumptionUpdate(building, timeFrom, timeTo);
            TemporalOtherPowerConsumptionUpdate(building, timeFrom, timeTo);
            TemporalTotalPowerConsumptionUpdate(building, timeFrom, timeTo);

        }

        public void TemporalUpdateAll(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            TemporalTemperatureUpdate(floor, timeFrom, timeTo);
            TemporalMotionDetectionUpdate(floor, timeFrom, timeTo);
            TemporalCO2Update(floor, timeFrom, timeTo);
            TemporalLuxUpdate(floor, timeFrom, timeTo);
            TemporalLightUpdate(floor, timeFrom, timeTo);
            TemporalLightUpdate(floor, timeFrom, timeTo);
            TemporalWifiClientUpdate(floor, timeFrom, timeTo);
            TemporalOccupantsUpdate(floor, timeFrom, timeTo);
            TemporalColdWaterUpdate(floor, timeFrom, timeTo);
            TemporalHotWaterUpdate(floor, timeFrom, timeTo);
            TemporalVentilationPowerConsumptionUpdate(floor, timeFrom, timeTo);
            TemporalHardwarePowerConsumptionUpdate(floor, timeFrom, timeTo);
            TemporalLightPowerConsumptionUpdate(floor, timeFrom, timeTo);
            TemporalOtherPowerConsumptionUpdate(floor, timeFrom, timeTo);
            TemporalTotalPowerConsumptionUpdate(floor, timeFrom, timeTo);
        }

        public void TemporalUpdateAll(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            TemporalTemperatureUpdate(room, timeFrom, timeTo);
            TemporalMotionDetectionUpdate(room, timeFrom, timeTo);
            TemporalCO2Update(room, timeFrom, timeTo);
            TemporalLuxUpdate(room, timeFrom, timeTo);
            TemporalLightUpdate(room, timeFrom, timeTo);
            TemporalLightUpdate(room, timeFrom, timeTo);
            TemporalWifiClientUpdate(room, timeFrom, timeTo);
            TemporalOccupantsUpdate(room, timeFrom, timeTo);
        }

        public void TemporalTemperatureUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                var floor in
                    building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalTemperatureUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalTemperatureUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>()
                )
            {
                TemporalTemperatureUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalTemperatureUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Temperature))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Temperature).Key,
                            timeFrom,
                            timeTo));
                room.AverageTemperature = temporalSummary.MeanValue;
                room.MinObservedTemperature = temporalSummary.MinValue;
                room.MaxObservedTemperature = temporalSummary.MaxValue;
            }
        }

        public void TemporalCO2Update(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                var floor in
                    building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
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
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.CO2).Key, timeFrom,
                            timeTo));
                room.AverageCO2 = temporalSummary.MeanValue;
                room.MinObservedCO2 = temporalSummary.MinValue;
                room.MaxObservedCO2 = temporalSummary.MaxValue;
            }
        }

        public void TemporalOccupantsUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                var floor in
                    building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalOccupantsUpdate(floor, timeFrom, timeTo);
            }

            if (building.Endpoints != null && building.Endpoints.SmapEndponts.ContainsValue(SensorType.Occupants))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            building.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Occupants).Key, timeFrom,
                            timeTo));
                building.AverageOccupants = temporalSummary.MeanValue;
                building.MinObservedOccupants = temporalSummary.MinValue;
                building.MaxObservedOccupants = temporalSummary.MaxValue;
            }
        }

        public void TemporalOccupantsUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>()
                )
            {
                TemporalOccupantsUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalOccupantsUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Occupants))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Occupants).Key, timeFrom,
                            timeTo));
                room.AverageOccupants = temporalSummary.MeanValue;
                room.MinObservedOccupants = temporalSummary.MinValue;
                room.MaxObservedOccupants = temporalSummary.MaxValue;
            }
        }

        public void TemporalMotionDetectionUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                var floor in
                    building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalMotionDetectionUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalMotionDetectionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>()
                )
            {
                TemporalMotionDetectionUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalMotionDetectionUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.MotionDetection))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcBooleanEventbasedValues(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.MotionDetection).Key, timeFrom,
                            timeTo),timeFrom,timeTo);
                room.AverageMotion = temporalSummary.MeanValue;
                room.MinObservedMotion = temporalSummary.MinValue;
                room.MaxObservedMotion = temporalSummary.MaxValue;
            }
        }

        public void TemporalWifiClientUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                var floor in
                    building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
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
            foreach (
                var floor in
                    building.Floors.Where(room => room.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalLightUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalLightUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>()
                )
            {
                TemporalLightUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalLightUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Light))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcBooleanEventbasedValues(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Light).Key, timeFrom,
                            timeTo), timeFrom,
                            timeTo);
                room.AverageLight = temporalSummary.MeanValue;
                room.MinObservedLight = temporalSummary.MinValue;
                room.MaxObservedLight = temporalSummary.MaxValue;
            }
        }


        public void TemporalLuxUpdate(TemporalRoom room, DateTime timeFrom, DateTime timeTo)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Lux))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Lux).Key, timeFrom,
                            timeTo));
                room.AverageLux = temporalSummary.MeanValue;
                room.MinObservedLux = temporalSummary.MinValue;
                room.MaxObservedLux = temporalSummary.MaxValue;
            }
        }

        public void TemporalLuxUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>()
                )
            {
                TemporalLuxUpdate(room, timeFrom, timeTo);
            }
        }

        public void TemporalLuxUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                TemporalFloor floor in
                    building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalLuxUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalHotWaterUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                TemporalFloor floor in
                    building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalHotWaterUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalHotWaterUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null && floor.Endpoints.SmapEndponts.ContainsValue(SensorType.HotWater))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.HotWater).Key, timeFrom,
                            timeTo));
                floor.AverageHotWaterConsumption = temporalSummary.MeanValue;
                floor.MinObservedHotWaterConsumption = temporalSummary.MinValue;
                floor.MaxObservedHotWaterConsumption = temporalSummary.MaxValue;
            }
        }

        public void TemporalColdWaterUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (
                TemporalFloor floor in
                    building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalColdWaterUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalColdWaterUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null && floor.Endpoints.SmapEndponts.ContainsValue(SensorType.ColdWater))
            {
                TemporalSummary temporalSummary =
                    calculateTemporalSummary.CalcValues(
                        smapDal.GetHistoricSensorValue(
                            floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.ColdWater).Key, timeFrom,
                            timeTo));
                floor.AverageColdWaterConsumption = temporalSummary.MeanValue;
                floor.MinObservedColdWaterConsumption = temporalSummary.MinValue;
                floor.MaxObservedColdWaterConsumption = temporalSummary.MaxValue;
            }
        }

        public void TemporalTotalPowerConsumptionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null)
            {
                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.TotalPowerConsumption))
                {

                    var endpoints = floor.Endpoints.SmapEndponts.Where(s => s.Value == SensorType.TotalPowerConsumption);

                    TemporalSummary temporalSummary =
                        calculateTemporalSummary.CalcSMapMinMaxMeanHourly(
                            smapDal.GetHistoricSensorValue(endpoints, timeFrom, timeTo));

                    floor.AverageTotalPowerConsumption = temporalSummary.MeanValue;
                    floor.MinObservedTotalPowerConsumption = temporalSummary.MinValue;
                    floor.MaxObservedTotalPowerConsumption = temporalSummary.MaxValue;
                }
            }
        }

        public void TemporalTotalPowerConsumptionUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalTotalPowerConsumptionUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalHardwarePowerConsumptionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null)
            {
                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.HardwarePowerConsumption))
                {

                    var endpoints = floor.Endpoints.SmapEndponts.Where(s => s.Value == SensorType.HardwarePowerConsumption);

                    TemporalSummary temporalSummary =
                        calculateTemporalSummary.CalcSMapMinMaxMeanHourly(
                            smapDal.GetHistoricSensorValue(endpoints, timeFrom, timeTo));

                    floor.AverageHardwareConsumption = temporalSummary.MeanValue;
                    floor.MinObservedHardwareConsumption = temporalSummary.MinValue;
                    floor.MaxObservedHardwareConsumption = temporalSummary.MaxValue;
                }
            }
        }

        public void TemporalHardwarePowerConsumptionUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalHardwarePowerConsumptionUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalLightPowerConsumptionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null)
            {
                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.LightPowerConsumption))
                {

                    var endpoints = floor.Endpoints.SmapEndponts.Where(s => s.Value == SensorType.LightPowerConsumption);

                    TemporalSummary temporalSummary =
                        calculateTemporalSummary.CalcSMapMinMaxMeanHourly(
                            smapDal.GetHistoricSensorValue(endpoints, timeFrom, timeTo));

                    floor.AverageLightConsumption= temporalSummary.MeanValue;
                    floor.MinObservedLightConsumption = temporalSummary.MinValue;
                    floor.MaxObservedLightConsumption = temporalSummary.MaxValue;
                }
            }
        }

        public void TemporalLightPowerConsumptionUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalLightPowerConsumptionUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalOtherPowerConsumptionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null)
            {
                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.OtherPowerConsumption))
                {

                    var endpoints = floor.Endpoints.SmapEndponts.Where(s => s.Value == SensorType.OtherPowerConsumption);

                    TemporalSummary temporalSummary =
                        calculateTemporalSummary.CalcSMapMinMaxMeanHourly(
                            smapDal.GetHistoricSensorValue(endpoints, timeFrom, timeTo));

                    floor.AverageOtherConsumption = temporalSummary.MeanValue;
                    floor.MinObservedOtherConsumption = temporalSummary.MinValue;
                    floor.MaxObservedOtherConsumption = temporalSummary.MaxValue;
                }
            }
        }

        public void TemporalOtherPowerConsumptionUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalOtherPowerConsumptionUpdate(floor, timeFrom, timeTo);
            }
        }

        public void TemporalVentilationPowerConsumptionUpdate(TemporalFloor floor, DateTime timeFrom, DateTime timeTo)
        {
            if (floor.Endpoints != null)
            {
                if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.VentilationPowerConsumption))
                {

                    var endpoints = floor.Endpoints.SmapEndponts.Where(s => s.Value == SensorType.VentilationPowerConsumption);

                    TemporalSummary temporalSummary =
                        calculateTemporalSummary.CalcSMapMinMaxMeanHourly(
                            smapDal.GetHistoricSensorValue(endpoints, timeFrom, timeTo));

                    floor.AverageVentilationConsumption = temporalSummary.MeanValue;
                    floor.MinObservedVentilationConsumption = temporalSummary.MinValue;
                    floor.MaxObservedVentilationConsumption = temporalSummary.MaxValue;
                }
            }
        }

        public void TemporalVentilationPowerConsumptionUpdate(TemporalBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            foreach (TemporalFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>())
            {
                TemporalVentilationPowerConsumptionUpdate(floor, timeFrom, timeTo);
            }
        }
    }
}