using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO.Buildings;

namespace Website.Logic.Domain
{
    public class LogicFacade
    {

        private TemporalManager temporalManager;
        private JsonConverter jsonLiveConverter;


        private static LogicFacade _instance;

        private LogicFacade()
        {
            temporalManager = new TemporalManager(new SMapManagerTemporalt(new SMAP()));
            jsonLiveConverter = new JsonConverter();
        }

        public static LogicFacade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogicFacade();
                }
                return _instance;
            }
        }

        public string ConvertBuilding()
        {
            return jsonLiveConverter.ConvertBuilding((LiveBuilding)HttpContext.Current.Application["Building"]);
        }

        public string ConvertBuilding(LiveBuilding building)
        {
            return jsonLiveConverter.ConvertBuilding(building);
        }

        public string ConvertFloors(int floorLevel)
        {
            return jsonLiveConverter.ConvertFloors(floorLevel);
        }

        public string ConvertRoomsGeoJson(int floorLevel)
        {
            return jsonLiveConverter.ConvertRoomsGeoJson(floorLevel);
        }

        public string ConvertRooms(int? floorLevel = null)
        {
            return jsonLiveConverter.ConvertRooms(floorLevel);
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