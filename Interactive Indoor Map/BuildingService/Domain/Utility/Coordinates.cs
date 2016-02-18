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
        public string XCoordinate { get; set; }

        [DataMember]
        public string YCoordinate { get; set; }
    }
}