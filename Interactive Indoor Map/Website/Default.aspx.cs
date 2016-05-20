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

namespace Website
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!ClientScript.IsStartupScriptRegistered("leaflet"))
                {
                    string jsonRooms = Facade.Instance.GetDrawableSensorRooms(1);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "InitLeafletMap(" + jsonRooms + ");", true);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "updateTimer", "startUpdateTimer();", true);

                }
            }
        }


        [System.Web.Services.WebMethod]
        public static string DrawFloor(int floorLevel)
        {
            return Facade.Instance.GetDrawableSensorRooms(floorLevel);
        }


        [System.Web.Services.WebMethod]
        public static string DrawRoomsBackground(int floorLevel)
        {
            return Facade.Instance.GetDrawableRooms(floorLevel);
        }

        [System.Web.Services.WebMethod]
        public static string DrawFloorInfobox(int floorLevel)
        {
            return Facade.Instance.GetFloorInfobox(floorLevel);
        }

        [System.Web.Services.WebMethod]
        public static string DrawBuildingInfoBox()
        {
            return Facade.Instance.GetBuildingInfobox();
        }

        [System.Web.Services.WebMethod]
        public static string GetTemporalBuildingInfoBox(DateTime timeFrom, DateTime timeTo)
        {
            return Facade.Instance.GetTemporalBuildingInfoBox(timeFrom, timeTo);
        }

        [System.Web.Services.WebMethod]
        public static string GetTemporalFloorInfoBox(int floorLevel,DateTime timeFrom, DateTime timeTo)
        {
            return Facade.Instance.GetTemporalFloorInfoBox(floorLevel, timeFrom, timeTo);
        }

        [System.Web.Services.WebMethod]
        public static string GetDrawableTemporalReadings(int floorLeel, DateTime timeFrom, DateTime timeTo)
        {
            return Facade.Instance.GetDrawableTemporalReadings(floorLeel, timeFrom, timeTo);
        }
    }
}