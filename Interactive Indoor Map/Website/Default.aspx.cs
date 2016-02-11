using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //var line = new GeoJSON.Net.Geometry.LineString(coordinates);
                //string json = JsonConvert.SerializeObject(line);
                //return Content(json, "application/json");

                if (!ClientScript.IsStartupScriptRegistered("leaflet"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(),
                        "leaflet", "leafletDraw();", true);
                }
            }
        }
    }
}