using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Website.DAL.ExternalData;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;
using Website.Logic.Helpers;

namespace Website.Logic.Domain
{
    public class SmapManager
    {
        private SMAP smapDal;

        public SmapManager(SMAP smapDal)
        {
            this.smapDal = smapDal;
        }

        public void LiveUpdateAllSensorss(LiveBuilding building)
        {
            TemperatureUpdate(building);
            Co2Update(building);
            LightUpdate(building);
            LuxUpdate(building);
            PowerConsumptionUpdate(building);
            WaterUpdate(building);
            OccupantsUpdate(building);
            WifiClientUpdate(building);
        }

        public void LiveUpdateAllSensorss(LiveBuilding building, DateTime timeFrom, DateTime timeTo)
        {
            TemperatureUpdate(building);
            Co2Update(building);
            LightUpdate(building);
            LuxUpdate(building);
            PowerConsumptionUpdate(building);
            WaterUpdate(building);
            WaterUpdate(building);
            OccupantsUpdate(building);
            WifiClientUpdate(building);
        }

        public void TemperatureUpdate(LiveBuilding building)
        {
            foreach (var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                TemperatureUpdate(floor);
            }
        }

        public void TemperatureUpdate(LiveFloor floor)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
            {
                TemperatureUpdate(room);
            }
        }

        public void TemperatureUpdate(LiveRoom room)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Temperature))
                room.Temperature =
                    smapDal.GetCurrentSensorValue(
                        room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Temperature).Key);
        }





        public void Co2Update(LiveBuilding building)
        {
            foreach (var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                Co2Update(floor);
            }
        }

        public void Co2Update(LiveFloor floor)
        {
            foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
            {
                Co2Update(room);
            }
        }

        public void Co2Update(LiveRoom room)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.CO2))

                room.CO2 = (int)smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.CO2).Key);
        }

        public void LightUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (
                    LiveRoom room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Light))
                        room.Light =
                            smapDal.GetCurrentSensorValue(
                                room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Light).Key).Equals(0.0);
                }
            }
        }

        public void LuxUpdate(LiveBuilding building)
        {
            foreach (LiveFloor floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                LuxUpdate(floor);
            }
        }

        public void LuxUpdate(LiveFloor floor)
        {
            foreach (LiveRoom room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
            {
                LuxUpdate(room);
            }
        }

        public void LuxUpdate(LiveRoom room)
        {
            if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Lux))
                room.Lux =
                    (int)
                        smapDal.GetCurrentSensorValue(
                            room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Lux).Key);
        }


        public void PowerConsumptionUpdate(LiveBuilding building)
        {
            foreach (
                var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                foreach (var room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
                {
                    if (room.Endpoints != null)
                    {
                        if (room.Endpoints.SmapEndponts.ContainsValue(SensorType.HardwarePowerConsumption))
                            room.HardwareConsumption = GetPoweruser(room.Endpoints.SmapEndponts,
                                SensorType.HardwarePowerConsumption);

                        if (room.Endpoints.SmapEndponts.ContainsValue(SensorType.LightPowerConsumption))
                            room.LightConsumption = GetPoweruser(room.Endpoints.SmapEndponts,
                                SensorType.LightPowerConsumption);

                        if (room.Endpoints.SmapEndponts.ContainsValue(SensorType.VentilationPowerConsumption))
                            room.VentilationConsumption = GetPoweruser(room.Endpoints.SmapEndponts,
                                SensorType.VentilationPowerConsumption);


                        if (room.Endpoints.SmapEndponts.ContainsValue(SensorType.OtherPowerConsumption))
                            room.OtherConsumption = GetPoweruser(room.Endpoints.SmapEndponts,
                                SensorType.OtherPowerConsumption);

                        if (room.Endpoints.SmapEndponts.ContainsValue(SensorType.TotalPowerConsumption))
                            room.TotalPowerConsumption = GetPoweruser(room.Endpoints.SmapEndponts,
                                SensorType.TotalPowerConsumption);

                    }
                }
                if (floor.Endpoints != null)
                {
                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.HardwarePowerConsumption))
                        floor.HardwareConsumption = GetPoweruser(floor.Endpoints.SmapEndponts,
                            SensorType.HardwarePowerConsumption);

                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.LightPowerConsumption))
                        floor.LightConsumption = GetPoweruser(floor.Endpoints.SmapEndponts,
                            SensorType.LightPowerConsumption);

                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.VentilationPowerConsumption))
                        floor.VentilationConsumption = GetPoweruser(floor.Endpoints.SmapEndponts,
                            SensorType.VentilationPowerConsumption);

                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.OtherPowerConsumption))
                        floor.OtherConsumption = GetPoweruser(floor.Endpoints.SmapEndponts,
                            SensorType.OtherPowerConsumption);

                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.TotalPowerConsumption))
                        floor.TotalPowerConsumption = GetPoweruser(floor.Endpoints.SmapEndponts,
                            SensorType.TotalPowerConsumption);

                }
            }
        }

        public void WaterUpdate(LiveBuilding building)
        {
            foreach (
                var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                if (floor.Endpoints != null)
                {
                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.HotWater))
                        floor.HotWaterConsumption =
                            smapDal.GetCurrentSensorValue(
                                floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.HotWater).Key);

                    if (floor.Endpoints.SmapEndponts.ContainsValue(SensorType.ColdWater))
                        floor.ColdWaterConsumption =
                            smapDal.GetCurrentSensorValue(
                                floor.Endpoints.SmapEndponts.First(s => s.Value == SensorType.ColdWater).Key);
                }
            }
        }

        public void MotionUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (
                    LiveRoom room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.MotionDetection))
                        room.Motion =
                            smapDal.GetCurrentSensorValue(
                                room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.MotionDetection).Key)
                                .Equals(1.0);
                }
            }
        }

        public void OccupantsUpdate(LiveBuilding building)
        {
            foreach (
                var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                foreach (
                    LiveRoom room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsValue(SensorType.Occupants))
                        room.Occupants =
                            (int)
                                smapDal.GetCurrentSensorValue(
                                    room.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Occupants).Key);
                }
            }

            if (building.Endpoints != null && building.Endpoints.SmapEndponts.ContainsValue(SensorType.Occupants))
            {
                building.Occupants =
                    (int)
                        smapDal.GetCurrentSensorValue(
                            building.Endpoints.SmapEndponts.First(s => s.Value == SensorType.Occupants).Key);
            }

        }

        public void WifiClientUpdate(LiveBuilding building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (
                    LiveRoom room in floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.WifiEndpoint != null)
                    {
                        //room.WifiClients = (int)smapDal.GetCurrentSensorValue(room.Endpoints.WifiEndpoint);
                    }
                }
            }
        }

        private double GetPoweruser(Dictionary<string, SensorType> smapEndpoints, SensorType sensorType)
        {
            double powerUser = 0.0;
            foreach (var smapEndpoint in smapEndpoints.Where(s => s.Value == sensorType))
            {
                powerUser += smapDal.GetCurrentHourlyUse(smapEndpoint.Key);
            }
            return powerUser;
        }

       
    }
}