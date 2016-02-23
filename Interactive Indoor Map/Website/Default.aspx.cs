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
        String json = "{\"type\": \"FeatureCollection\", \"features\": [{ \"type\": \"Feature\", \"properties\": { \"stroke\": \"#FFFFFF\", \"stroke-width\": 2, \"stroke-opacity\": 1, \"fill\": \"#000000\", \"fill-opacity\": 0.5, \"name\": \"Ø20-604-0\" }, \"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [ [10.430603921413422, 55.36697392651307], [10.430810451507568, 55.36698307259987], [10.430764853954315, 55.367210199744484], [10.430574417114258, 55.36719952937089], [10.430603921413422, 55.36697392651307] ] ] } }" +
                              ", { \"type\": \"Feature\", \"properties\": { \"stroke\": \"#FFFFFF\", \"stroke-width\": 2, \"stroke-opacity\": 1, \"fill\": \"#FFFFFF\", \"fill-opacity\": 0.5, \"name\": \"Ø22-508-0\", \"power\" : 20, \"floor\" : 2 }, \"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [ [10.43104112148285, 55.36767664469221], [10.430856049060822, 55.36767207172922], [10.430874824523926, 55.367451044554315], [10.431067943572998, 55.36746171486007], [10.43104112148285, 55.36767664469221] ] ] } }]}";

        //private string testJson;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                 //json = @"'map/map.json'";
                //Session["Map"] = json;
                
                //var line = new GeoJSON.Net.Geometry.LineString(coordinates);
                //string json = JsonConvert.SerializeObject(line);
                //return Content(json, "application/json");

                if (!ClientScript.IsStartupScriptRegistered("leaflet"))
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(),"leaflet", "leafletDraw(" + json + ");", true);
                }
            }
        }

        public void DrawBuilding(object sender, EventArgs e)
        {
            //Application.Lock();
            //Application["dsgerd"] = "fisk";
            GeoJsonConverter converter = new GeoJsonConverter();

            String testJson = converter.Convert((Building)Application["Building"], 0);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "leaflet", "leafletDraw(" + testJson + ");", true);
        }
    }
}