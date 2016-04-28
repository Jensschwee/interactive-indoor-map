using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Timers;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
{
    public class RealTimeUpdater
    {
        LiveBuilding building = (LiveBuilding)HttpContext.Current.Application["Building"];
        private SmapManager smapManager;
        private int temperatureUpdateInterval = 5000;
        private int co2UpdateInterval = 5000;
        private int lightUpdateInterval = 5000;
        private int lumenUpdateInterval = 5000;
        private int powerConsumptionInterval = 5000;
        private int waterUpdateInterval = 5000;
        private int motionDetectedUpdateInterval = 5000;
        private int occupantsUpdateInterval = 5000;
        private int wifiClientsUpdateInterval = 5000;

        public RealTimeUpdater(LiveBuilding building, SmapManager smapManager)
        {
            this.building = building;
            this.smapManager = smapManager;
        }

        public RealTimeUpdater(LiveBuilding building, SmapManager smapManager, int temperatureUpdateInterval, int co2UpdateInterval, int lightUpdateInterval, int lumenUpdateInterval, int powerConsumptionInterval, int waterUpdateInterval, int motionDetectedUpdateInterval, int occupantsUpdateInterval, int wifiClientsUpdateInterval) : this(building, smapManager)
        {
            this.temperatureUpdateInterval = temperatureUpdateInterval;
            this.co2UpdateInterval = co2UpdateInterval;
            this.lightUpdateInterval = lightUpdateInterval;
            this.lumenUpdateInterval = lumenUpdateInterval;
            this.powerConsumptionInterval = powerConsumptionInterval;
            this.waterUpdateInterval = waterUpdateInterval;
            this.motionDetectedUpdateInterval = motionDetectedUpdateInterval;
            this.occupantsUpdateInterval = occupantsUpdateInterval;
            this.wifiClientsUpdateInterval = wifiClientsUpdateInterval;
        }


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
            smapManager.TemperatureUpdate(building);
        }

        private void OnCO2TimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.Co2Update(building);
        }

        private void OnLightTimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.LightUpdate(building);
        }

        private void OnLumenTimedEvent(object source, ElapsedEventArgs e)
        {

            smapManager.LumenUpdate(building);
        }

        private void OnPowerConsumptionTimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.PowerConsumptionUpdate(building);
        }

        private void OnWaterTimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.WaterUpdate(building);
        }

        private void OnMotionTimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.MotionUpdate(building);
        }

        private void OnOccupantsTimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.OccupantsUpdate(building);
        }

        private void OnWifiClientsTimedEvent(object source, ElapsedEventArgs e)
        {
            smapManager.WifiClientUpdate(building);
        }
    }
}