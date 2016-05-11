using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.Domain;
using JsonConverter = Website.Logic.Domain.JsonConverter;

namespace Website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Session["FloorLevel"] = 0;
                if (!ClientScript.IsStartupScriptRegistered("leaflet"))
                {
                    string jsonRooms = LogicFacade.Instance.ConvertRooms(1);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "InitLeafletMap(" + jsonRooms + ");", true);
                }
            }
        }


        [System.Web.Services.WebMethod]
        public static string DrawFloor(int floorLevel)
        {
            return LogicFacade.Instance.ConvertRooms(floorLevel);
        }


        [System.Web.Services.WebMethod]
        public static string DrawRoomsBackground(int floorLevel)
        {
            return LogicFacade.Instance.ConvertRoomsGeoJson(floorLevel);
        }

        [System.Web.Services.WebMethod]
        public static string DrawFloorInfoBox(int floorLevel)
        {
            return LogicFacade.Instance.ConvertFloors(floorLevel);
        }

        [System.Web.Services.WebMethod]
        public static string DrawBuildingInfoBox()
        {
            return LogicFacade.Instance.ConvertBuilding();
        }

        [System.Web.Services.WebMethod]
        public static string GetTemporalBuildingInfoBox(DateTime timeFrom, DateTime timeTo)
        {
            return LogicFacade.Instance.GetTemporalBuildingInfoBox(timeFrom, timeTo);
        }

        [System.Web.Services.WebMethod]
        public static string GetTemporalFloorInfoBox(int floorLevel,DateTime timeFrom, DateTime timeTo)
        {
            return LogicFacade.Instance.GetTemporalFloorInfoBox(floorLevel, timeFrom, timeTo);
        }

        [System.Web.Services.WebMethod]
        public static string GetDrawableTemporalFloorReadings(int floorLeel, DateTime timeFrom, DateTime timeTo)
        {
            return LogicFacade.Instance.GetDrawableTemporalFloorReadings(floorLeel, timeFrom, timeTo);
        }
    }
}