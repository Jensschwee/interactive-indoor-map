using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Web;

namespace BuildingService.Domain
{
    [DataContract]
    public class FloorDimensons
    {
        [DataMember]
        public int FloorLevel { get; set; }

        [DataMember]
        public List<RoomDimensions> Rooms { get; set; }
    }
}