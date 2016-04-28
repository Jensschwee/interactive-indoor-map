using System.Linq;
using Website.DAL.ExternalData;
using Website.Logic.BO;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
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
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsKey(SensorType.Temperature))
                        room.Temperature = smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.Temperature).Value);
                }
            }
        }

        public void Co2Update(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsKey(SensorType.CO2))

                        room.CO2 = (int)smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.CO2).Value);
                }
            }
        }

        public void LightUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsKey(SensorType.Light))
                        room.Light = smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.Light).Value).Equals(0.0);
                }
            }
        }

        public void LumenUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsKey(SensorType.Lumen))
                        room.Lumen = (int)smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.Lumen).Value);
                }
            }
        }

        public void PowerConsumptionUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if(room.Endpoints != null)
                    { 
                    if (room.Endpoints.SmapEndponts.ContainsKey(SensorType.HardwarePowerConsumption))
                        room.HardwareConsumption = smapDal.GetCurrentHourlyUse(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.HardwarePowerConsumption).Value);

                    if (room.Endpoints.SmapEndponts.ContainsKey(SensorType.LightPowerConsumption))
                        room.LightConsumption = smapDal.GetCurrentHourlyUse(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.LightPowerConsumption).Value);

                    if (room.Endpoints.SmapEndponts.ContainsKey(SensorType.VentilationPowerConsumption))
                        room.VentilationConsumption = smapDal.GetCurrentHourlyUse(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.VentilationPowerConsumption).Value);

                    if (room.Endpoints.SmapEndponts.ContainsKey(SensorType.OtherPowerConsumption))
                        room.OtherConsumption = smapDal.GetCurrentHourlyUse(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.OtherPowerConsumption).Value);

                    }
                }
            }
        }

        public void WaterUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                if(floor.Endpoints != null)
                { 
                if(floor.Endpoints.SmapEndponts.ContainsKey(SensorType.HotWater))
                    floor.HotWaterConsumption = smapDal.GetCurrentSensorValue(floor.Endpoints.SmapEndponts.First(s => s.Key == SensorType.HotWater).Value);

                if (floor.Endpoints.SmapEndponts.ContainsKey(SensorType.ColdWater))
                    floor.ColdWaterConsumption = smapDal.GetCurrentSensorValue(floor.Endpoints.SmapEndponts.First(s => s.Key == SensorType.ColdWater).Value);
                }
            }
        }

        public void MotionUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsKey(SensorType.MotionDetection))
                        room.Motion = smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.MotionDetection).Value).Equals(1.0);
                }
            }
        }

        public void OccupantsUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if (room.Endpoints != null && room.Endpoints.SmapEndponts.ContainsKey(SensorType.Occupants))
                        room.Occupants = (int)smapDal.GetCurrentSensorValue(room.Endpoints.SmapEndponts.First(s => s.Key == SensorType.Occupants).Value);
                }
            }

            if (building.Endpoints != null && building.Endpoints.SmapEndponts.ContainsKey(SensorType.Occupants))
            {
                building.Occupants = (int)smapDal.GetCurrentSensorValue(building.Endpoints.SmapEndponts.First(s => s.Key == SensorType.Occupants).Value);
            }

        }

        public void WifiClientUpdate(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if(room.Endpoints != null && room.Endpoints.WifiEndpoint != null)
                        room.WifiClients = (int)smapDal.GetCurrentSensorValue(room.Endpoints.WifiEndpoint);
                }
            }
        }
    }
}