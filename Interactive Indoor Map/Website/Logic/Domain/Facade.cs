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

        private static Facade _instance;

        private Facade()
        {
            temporalManager = new TemporalManager(new TemporalSMapManager(new SMAP()));
            liveJsonLiveConverter = new LiveJsonConverter();
        }

        public static Facade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Facade();
                }
                return _instance;
            }
        }

        public string ConvertBuilding()
        {
            return liveJsonLiveConverter.ConvertBuilding((LiveBuilding)HttpContext.Current.Application["Building"]);
        }

        public string ConvertBuilding(LiveBuilding building)
        {
            return liveJsonLiveConverter.ConvertBuilding(building);
        }

        public string ConvertFloors(int floorLevel)
        {
            return liveJsonLiveConverter.ConvertFloors(floorLevel);
        }

        public string ConvertRoomsGeoJson(int floorLevel)
        {
            return liveJsonLiveConverter.ConvertRoomsGeoJson(floorLevel);
        }

        public string ConvertRooms(int? floorLevel = null)
        {
            return liveJsonLiveConverter.ConvertRooms(floorLevel);
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