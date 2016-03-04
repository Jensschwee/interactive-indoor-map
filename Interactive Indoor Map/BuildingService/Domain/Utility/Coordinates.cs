using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;

namespace BuildingService.Domain.Utility
{
    [DataContract]
    public class Coordinates
    {
        [DataMember]
        public double XCoordinate { get; set; }

        [DataMember]
        public double YCoordinate { get; set; }

        public Coordinates() { }

        public Coordinates( double xCoordinate, double yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}