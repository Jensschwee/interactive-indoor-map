﻿using System;
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
        private LiveSMapManager _liveSMapManager;
        private readonly int temperatureUpdateInterval = 5000;
        private readonly int co2UpdateInterval = 5000;
        private readonly int lightUpdateInterval = 5000;
        private readonly int luxUpdateInterval = 5000;
        private readonly int powerConsumptionInterval = 5000;
        private readonly int waterUpdateInterval = 5000;
        private readonly int motionDetectedUpdateInterval = 5000;
        private readonly int occupantsUpdateInterval = 5000;
        private readonly int wifiClientsUpdateInterval = 5000;

        public RealTimeUpdater(LiveBuilding building, LiveSMapManager _liveSMapManager)
        {
            this.building = building;
            this._liveSMapManager = _liveSMapManager;
        }

        public RealTimeUpdater(LiveBuilding building, LiveSMapManager _liveSMapManager, int temperatureUpdateInterval, int co2UpdateInterval, int lightUpdateInterval, int luxUpdateInterval, int powerConsumptionInterval, int waterUpdateInterval, int motionDetectedUpdateInterval, int occupantsUpdateInterval, int wifiClientsUpdateInterval) : this(building, _liveSMapManager)
        {
            this.temperatureUpdateInterval = temperatureUpdateInterval;
            this.co2UpdateInterval = co2UpdateInterval;
            this.lightUpdateInterval = lightUpdateInterval;
            this.luxUpdateInterval = luxUpdateInterval;
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

            Timer luxUpdater = new Timer();
            luxUpdater.Elapsed += new ElapsedEventHandler(OnLuxTimedEvent);
            luxUpdater.Interval = luxUpdateInterval;
            luxUpdater.Enabled = true;

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
            _liveSMapManager.TemperatureUpdate(building);
        }

        private void OnCO2TimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.Co2Update(building);
        }

        private void OnLightTimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.LightUpdate(building);
        }

        private void OnLuxTimedEvent(object source, ElapsedEventArgs e)
        {

            _liveSMapManager.LuxUpdate(building);
        }

        private void OnPowerConsumptionTimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.PowerConsumptionUpdate(building);
        }

        private void OnWaterTimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.WaterUpdate(building);
        }

        private void OnMotionTimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.MotionUpdate(building);
        }

        private void OnOccupantsTimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.OccupantsUpdate(building);
        }

        private void OnWifiClientsTimedEvent(object source, ElapsedEventArgs e)
        {
            _liveSMapManager.WifiClientUpdate(building);
        }
    }
}