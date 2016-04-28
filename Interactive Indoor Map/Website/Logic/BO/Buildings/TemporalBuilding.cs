using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Buildings
{
    public class TemporalBuilding : Building
    {
        public TemporalBuilding()
        {
            Floors = new List<Floor>();
        }
    }
}