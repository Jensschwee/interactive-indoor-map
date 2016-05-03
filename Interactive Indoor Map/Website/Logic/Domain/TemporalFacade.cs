using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using Website.DAL.ExternalData;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;

namespace Website.Logic.Domain
{
    public class TemporalFacade
    {
        private TemporalManager temporalManager;

        private static TemporalFacade _instance;

        private TemporalFacade()
        {
            temporalManager = new TemporalManager(new SMapManagerTemporalt(new SMAP()));

        }

        public static TemporalFacade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TemporalFacade();
                }
                return _instance;
            }
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