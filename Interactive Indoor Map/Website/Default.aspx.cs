using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Website.BO;
using Website.Domain;

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
                if (!ClientScript.IsStartupScriptRegistered("leaflet"))
                {
                    GeoJsonConverter converter = new GeoJsonConverter();

                    String json = converter.Convert((Building)Application["Building"], 0);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "leafletDraw(" + json + ");", true);
                }
            }
        }

        public void DrawBuilding(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["dsgerd"] = "fisk";
            //GeoJsonConverter converter = new GeoJsonConverter();

            //String testJson = converter.Convert((Building)Application["Building"], 0);

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "leafletDraw(" + testJson + ");", true);

          }


        [System.Web.Services.WebMethod]
        public static string DrawFloor(int floorLevel)
        {
            GeoJsonConverter converter = new GeoJsonConverter();

            return converter.Convert(floorLevel);
        }
    }
}