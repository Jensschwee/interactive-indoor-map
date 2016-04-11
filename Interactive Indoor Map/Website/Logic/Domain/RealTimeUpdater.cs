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
        Building building = (Building)HttpContext.Current.Application["Building"];
        private readonly string electricitySmapRoot = "OU44-EnergyKey";
        private readonly string otherSmapRoot = "OpcUa";
        private int temperatureUpdateInterval = 5000;
        private int co2UpdateInterval = 5000;
        private int lightUpdateInterval = 5000;
        private int lumenUpdateInterval = 5000;
        private int powerConsumptionInterval = 5000;
        private int waterUpdateInterval = 5000;
        private int motionDetectedUpdateInterval = 5000;
        private int occupantsUpdateInterval = 5000;
        private int wifiClientsUpdateInterval = 5000;

        public void CreateUpdateTimers()
        {
            Timer temperatureUpdater = new Timer();
            temperatureUpdater.Elapsed += new ElapsedEventHandler(OnTemperatureTimedEvent);
            temperatureUpdater.Interval = temperatureUpdateInterval;
            temperatureUpdater.Enabled = true;

            Timer co2Updater = new Timer();
            co2Updater.Elapsed += new ElapsedEventHandler(OnCO2TimedEvent);
            co2Updater.Interval = co2UpdateInterval;
            co2Updater.Enabled = true;

            Timer lightUpdater = new Timer();
            lightUpdater.Elapsed += new ElapsedEventHandler(OnLightTimedEvent);
            lightUpdater.Interval = lightUpdateInterval;
            lightUpdater.Enabled = true;

            Timer lumenUpdater = new Timer();
            lumenUpdater.Elapsed += new ElapsedEventHandler(OnLumenTimedEvent);
            lumenUpdater.Interval = lumenUpdateInterval;
            lumenUpdater.Enabled = true;

            Timer powerConsumptionUpdater = new Timer();
            powerConsumptionUpdater.Elapsed += new ElapsedEventHandler(OnPowerConsumptionTimedEvent);
            powerConsumptionUpdater.Interval = powerConsumptionInterval;
            powerConsumptionUpdater.Enabled = true;

            Timer waterUpdater = new Timer();
            waterUpdater.Elapsed += new ElapsedEventHandler(OnWaterTimedEvent);
            waterUpdater.Interval = waterUpdateInterval;
            waterUpdater.Enabled = true;

            Timer motionUpdater = new Timer();
            motionUpdater.Elapsed += new ElapsedEventHandler(OnMotionTimedEvent);
            motionUpdater.Interval = motionDetectedUpdateInterval;
            motionUpdater.Enabled = true;

            Timer occupancyUpdater = new Timer();
            occupancyUpdater.Elapsed += new ElapsedEventHandler(OnOccupantsTimedEvent);
            occupancyUpdater.Interval = occupantsUpdateInterval;
            occupancyUpdater.Enabled = true;

            Timer wifiClientsUpdater = new Timer();
            wifiClientsUpdater.Elapsed += new ElapsedEventHandler(OnWifiClientsTimedEvent);
            wifiClientsUpdater.Interval = wifiClientsUpdateInterval;
            wifiClientsUpdater.Enabled = true;
        }

        private void OnTemperatureTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Temperature = smap.GetCurrentSensorValue(room.SmapEndpoints.TemperatureUUID, otherSmapRoot);
                }
            }
        }

        private void OnCO2TimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.CO2 = (int)smap.GetCurrentSensorValue(room.SmapEndpoints.CO2UUID, otherSmapRoot);
                }
            }
        }

        private void OnLightTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Light = smap.GetCurrentSensorValue(room.SmapEndpoints.LightUUID, otherSmapRoot).Equals(0.0);
                }
            }
        }

        private void OnLumenTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Lumen = (int)smap.GetCurrentSensorValue(room.SmapEndpoints.LumenUUID, otherSmapRoot);
                }
            }
        }

        private void OnPowerConsumptionTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.HardwareConsumption = smap.GetCurrentSensorValue(room.SmapEndpoints.HardwarePowerConsumptionUUID, otherSmapRoot);
                    room.LightConsumption = smap.GetCurrentSensorValue(room.SmapEndpoints.LightPowerConsumptionUUID, otherSmapRoot);
                    room.VentilationConsumption = smap.GetCurrentSensorValue(room.SmapEndpoints.VentilationPowerConsumptionUUID, otherSmapRoot);
                    room.OtherConsumption = smap.GetCurrentSensorValue(room.SmapEndpoints.OtherPowerConsumptionUUID, otherSmapRoot);
                }
            }
        }

        private void OnWaterTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                floor.HotWaterConsumption = smap.GetCurrentSensorValue(floor.SmapEndpoints.HotWaterConsumptionUUID,
                    otherSmapRoot);
                floor.ColdWaterConsumption = smap.GetCurrentSensorValue(floor.SmapEndpoints.ColdWaterConsumptionUUID,
                    otherSmapRoot);
            }
        }

        private void OnMotionTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Motion = smap.GetCurrentSensorValue(room.SmapEndpoints.MotionDetectionUUID, otherSmapRoot).Equals(0.0);
                }
            }
        }

        private void OnOccupantsTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.Occupants = (int)smap.GetCurrentSensorValue(room.SmapEndpoints.OccupantsUUID, otherSmapRoot);
                }
            }
        }

        private void OnWifiClientsTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorRoom room in floor.Rooms.Where(room => room.GetType() == typeof(SensorRoom)).Cast<SensorRoom>())
                {
                    room.WifiClients = (int)smap.GetCurrentSensorValue(room.SmapEndpoints.WifiClientsUUID, otherSmapRoot);
                }
            }
        }
    }
}