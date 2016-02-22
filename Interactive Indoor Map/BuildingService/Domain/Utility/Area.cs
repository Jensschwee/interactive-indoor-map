using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingService.Domain.Utility
{
    public class Area
    {
        public List<Coordinates> Vertices { get; set; }

        public Area(Area areaToCopy)
        {
            Vertices = areaToCopy.Vertices;
        }
    }
}