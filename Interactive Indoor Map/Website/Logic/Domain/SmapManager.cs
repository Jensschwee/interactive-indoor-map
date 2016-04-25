using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO;

namespace Website.Logic
{
    public class SmapManager
    {
        private SMAP smapDal;
        public SmapManager(SMAP smapDal)
        {
            this.smapDal = smapDal;
        }

        public void UpdateAllSensorss(Building building)
        {
            TemperatureUpdate(building);
            Co2Update(building);
            LightUpdate(building);
            LumenUpdate(building);
            PowerConsumptionUpdate(building);
            WaterUpdate(building);
            WaterUpdate(building);
            OccupantsUpdate(building);
            WifiClientUpdate(building);
        }

        public void TemperatureUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Temperature = smapDal.GetCurrentSensorValue(room.SmapEndpoints.TemperatureUUID);
                }
            }
        }

        public void Co2Update(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.CO2 = (int)smapDal.GetCurrentSensorValue(room.SmapEndpoints.CO2UUID);
                }
            }
        }

        public void LightUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Light = smapDal.GetCurrentSensorValue(room.SmapEndpoints.LightUUID).Equals(0.0);
                }
            }
        }

        public void LumenUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Lumen = (int)smapDal.GetCurrentSensorValue(room.SmapEndpoints.LumenUUID);
                }
            }
        }

        public void PowerConsumptionUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.HardwareConsumption = smapDal.GetCurrentHourlyUse(room.SmapEndpoints.HardwarePowerConsumptionUUID);
                    room.LightConsumption = smapDal.GetCurrentHourlyUse(room.SmapEndpoints.LightPowerConsumptionUUID);
                    room.VentilationConsumption = smapDal.GetCurrentHourlyUse(room.SmapEndpoints.VentilationPowerConsumptionUUID);
                    room.OtherConsumption = smapDal.GetCurrentHourlyUse(room.SmapEndpoints.OtherPowerConsumptionUUID);
                }
            }
        }

        public void WaterUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                floor.HotWaterConsumption = smapDal.GetCurrentSensorValue(floor.SmapEndpoints.HotWaterConsumptionUUID);
                floor.ColdWaterConsumption = smapDal.GetCurrentSensorValue(floor.SmapEndpoints.ColdWaterConsumptionUUID);
            }
        }

        public void MotionUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Motion = smapDal.GetCurrentSensorValue(room.SmapEndpoints.MotionDetectionUUID).Equals(0.0);
                }
            }
        }

        public void OccupantsUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Occupants = (int)smapDal.GetCurrentSensorValue(room.SmapEndpoints.OccupantsUUID);
                }
            }
        }

        public void WifiClientUpdate(Building building)
        {
            //foreach (Floor floor in building.Floors)
            //{
            //    foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
            //    {
            //        //room.WifiClients = (int)smapDal.GetCurrentSensorValue(room.SmapEndpoints.WifiClientsUUID);
            //    }
            //}
        }
    }
}