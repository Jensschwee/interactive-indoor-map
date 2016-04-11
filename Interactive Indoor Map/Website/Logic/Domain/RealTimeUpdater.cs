using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Timers;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
{
    public class RealTimeUpdater
    {
        private SMAP smap = new SMAP();
        private readonly string electricitySmapRoot = "OU44-EnergyKey";
        private readonly string otherSmapRoot = "OpcUa";

        public void Updater()
        {
            Timer motionUpdater = new Timer();
            motionUpdater.Elapsed += (sender, e) => OnTimedEvent(sender, e, SensorType.MotionDetection);
            //motionUpdater.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            motionUpdater.Interval = 1000;
            motionUpdater.Enabled = true;

            Timer temperatureUpdater = new Timer();
            motionUpdater.Interval = 1000;
            motionUpdater.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e, SensorType type)
        {
            Building building = (Building) HttpContext.Current.Application["Building"];

            foreach (Floor floor in building.Floors)
            {
                if (type == SensorType.HotWater)
                {
                    floor.HotWaterConsumption = smap.GetCurrentSensorValue(
                        floor.SmapEndpoints.HotWaterConsumptionUUID,
                        otherSmapRoot);
                }

                if (type == SensorType.ColdWater)
                {
                    floor.ColdWaterConsumption = smap.GetCurrentSensorValue(
                        floor.SmapEndpoints.ColdWaterConsumptionUUID,
                        otherSmapRoot);
                }

                foreach (SensorRoom sensorRoom in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    if (type == SensorType.Temperature)
                    {
                        sensorRoom.Temperature = smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.TemperatureUUID, otherSmapRoot);
                    }

                    if (type == SensorType.CO2)
                    {
                        sensorRoom.CO2 = (int)smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.CO2UUID, otherSmapRoot);
                    }

                    if (type == SensorType.Lumen)
                    {
                        sensorRoom.Lumen = (int)smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.LumenUUID, otherSmapRoot);
                    }

                    if (type == SensorType.HardwarePowerConsumption)
                    {
                        sensorRoom.HardwareConsumption =
                            smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.HardwarePowerConsumptionUUID,
                                electricitySmapRoot);
                    }

                    if (type == SensorType.LightPowerConsumption)
                    {
                        sensorRoom.LightConsumption =
                            smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.LightPowerConsumptionUUID,
                                electricitySmapRoot);
                    }

                    if (type == SensorType.VentilationPowerConsumption)
                    {
                        sensorRoom.VentilationConsumption =
                            smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.VentilationPowerConsumptionUUID,
                                electricitySmapRoot);
                    }

                    if (type == SensorType.OtherPowerConsumption)
                    {
                        sensorRoom.OtherConsumption =
                            smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.OtherPowerConsumptionUUID,
                                electricitySmapRoot);
                    }

                    if (type == SensorType.MotionDetection)
                    {
                        sensorRoom.Motion = smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.MotionDetectionUUID, otherSmapRoot).Equals(0.0);
                    }

                    if (type == SensorType.Occupants)
                    {
                        sensorRoom.Occupants = 
                            (int)smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.OccupantsUUID,
                                otherSmapRoot);
                    }

                    if (type == SensorType.WifiClients)
                    {
                        sensorRoom.WifiClients =
                            (int) smap.GetCurrentSensorValue(sensorRoom.SmapEndpoints.WifiClientsUUID,
                                otherSmapRoot);
                    }
                }
            }

        }
    }
}