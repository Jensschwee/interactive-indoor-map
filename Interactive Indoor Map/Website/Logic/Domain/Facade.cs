using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO.Buildings;

namespace Website.Logic.Domain
{
    public class Facade
    {
        private TemporalManager temporalManager;
        private LiveJsonConverter liveJsonLiveConverter;

        private static Facade instance;

        private Facade()
        {
            temporalManager = new TemporalManager(new TemporalSMapManager(new SMAP()));
            liveJsonLiveConverter = new LiveJsonConverter();
        }

        public static Facade Instance
        {
            get { return instance ?? (instance = new Facade()); }
        }

        public string GetBuildingInfobox()
        {
            return liveJsonLiveConverter.GetBuildingInfobox((LiveBuilding)HttpContext.Current.Application["Building"]);
        }

        public string GetBuildingInfobox(LiveBuilding building)
        {
            return liveJsonLiveConverter.GetBuildingInfobox(building);
        }

        public string GetFloorInfobox(int floorLevel)
        {
            return liveJsonLiveConverter.GetFloorInfobox(floorLevel);
        }

        public string GetDrawableRooms(int floorLevel)
        {
            return liveJsonLiveConverter.GetDrawableRooms(floorLevel);
        }

        public string GetDrawableSensorRooms(int? floorLevel = null)
        {
            return liveJsonLiveConverter.GetDrawableSensorRooms(floorLevel);
        }


        public string GetTemporalFloorInfoBox(int floorLevel, DateTime timeFrom,
            DateTime timeTo)
        {
            return temporalManager.GetTemporalFloorInfoBox(floorLevel,
                (LiveBuilding)HttpContext.Current.Application["Building"], timeFrom, timeTo);
        }

        public string GetTemporalBuildingInfoBox(DateTime timeFrom, DateTime timeTo)
        {
            return temporalManager.GetTemporalBuildingInfoBox(
                (LiveBuilding)HttpContext.Current.Application["Building"], timeFrom, timeTo);
        }

        public string GetDrawableTemporalFloorReadings(int floorLevel, DateTime timeFrom,
            DateTime timeTo)
        {
            return temporalManager.GetDrawableTemporalFloorReadings(floorLevel,
                (LiveBuilding)HttpContext.Current.Application["Building"], timeFrom, timeTo);

        }
    }
}