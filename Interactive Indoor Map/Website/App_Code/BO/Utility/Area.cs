using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.BO.Utility
{
    public class Area
    {
        public List<Coordinates> Vertices { get; set; }

        public Area() { }

        public Area(List<Coordinates> vertices)
        {
            Vertices = vertices;
        }

        public Area(Area areaToCopy)
        {
            Vertices = areaToCopy.Vertices;
        }
    }
}