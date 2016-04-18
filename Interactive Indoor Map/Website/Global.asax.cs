using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Website.DAL.ExternalData;
using Website.Logic;
using Website.Logic.BO;
using Website.Logic.Domain;

namespace Website
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            BuildingSetup setup = new BuildingSetup();
            Building building = setup.CreateBuilding();
            setup.SetupBuilding(building);

            //Website.DAL.ExternalData.SMAP smapDal = new SMAP();
            //SmapManager smapManager = new SmapManager(smapDal);
            //smapManager.UpdateAllSensorss(building);
            //RealTimeUpdater smapTimerUpdater = new RealTimeUpdater(building,smapManager);
            //smapTimerUpdater.CreateUpdateTimers();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}