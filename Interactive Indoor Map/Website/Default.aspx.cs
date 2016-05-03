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
        
        //private string testJson;
        //private static Building building = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Session["FloorLevel"] = 0;
                if (!ClientScript.IsStartupScriptRegistered("leaflet"))
                {
                    JsonConverter converter = new JsonConverter();

                    string jsonRooms = converter.ConvertRooms((LiveBuilding)Application["Building"], 1);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "InitLeafletMap(" + jsonRooms + ");", true);
                }
            }
        }

        public void DrawBuilding(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["dsgerd"] = "fisk";
            //JsonConverter converter = new JsonConverter();

            //String testJson = converter.ConvertRooms((Building)Application["Building"], 0);

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "InitLeafletMap(" + testJson + ");", true);

          }


        [System.Web.Services.WebMethod]
        public static string DrawFloor(int floorLevel)
        {
            JsonConverter converter = new JsonConverter();

            return converter.ConvertRooms(floorLevel);
        }


        [System.Web.Services.WebMethod]
        public static string DrawRoomsBackgrund(int floorLevel)
        {
            JsonConverter converter = new JsonConverter();

            return converter.ConvertRoomsGeoJson(floorLevel);
        }

        [System.Web.Services.WebMethod]
        public static string DrawFloorInfoBox(int floorLevel)
        {
            JsonConverter converter = new JsonConverter();

            return converter.ConvertFloors(floorLevel);
        }

        [System.Web.Services.WebMethod]
        public static string DrawBuildingInfoBox()
        {
            JsonConverter converter = new JsonConverter();

            return converter.ConvertBuilding();
        }

        [System.Web.Services.WebMethod]
        public static string GetTemporalBuildingInfoBox(DateTime timeFrom, DateTime timeTo)
        {
            return TemporalFacade.Instance.GetTemporalBuildingInfoBox(timeFrom, timeTo);
        }

        [System.Web.Services.WebMethod]
        public static string GetTemporalFloorInfoBox(int floorLevel,DateTime timeFrom, DateTime timeTo)
        {
            return TemporalFacade.Instance.GetTemporalFloorInfoBox(floorLevel, timeFrom, timeTo);
        }

        [System.Web.Services.WebMethod]
        public static string GetDrawableTemporalFloorReadings(int floorLeel, DateTime timeFrom, DateTime timeTo)
        {
            return TemporalFacade.Instance.GetDrawableTemporalFloorReadings(floorLeel, timeFrom, timeTo);
        }
    }
}