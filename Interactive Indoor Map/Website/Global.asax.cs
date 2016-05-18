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
using Website.Logic.BO.Buildings;
using Website.Logic.Domain;

namespace Website
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            BuildingSetup setup = new BuildingSetup();
            LiveBuilding building = setup.CreateBuilding();
            setup.SetupBuilding(building);

            SMAP smapDal = new SMAP();
            LiveSMapManager _liveSMapManager = new LiveSMapManager(smapDal);
            //DB call
            //RealTimeUpdater smapTimerUpdater = new RealTimeUpdater((LiveBuilding)HttpContext.Current.Application["Building"], LiveSMapManager);

            //No DB call
            RealTimeUpdater smapTimerUpdater = new RealTimeUpdater(building, _liveSMapManager);

            smapTimerUpdater.CreateUpdateTimers();
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