using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BuildingService.Domain.Utility;

namespace BuildingService.Domain
{
    [DataContract]
    public class RoomDimensions
    {
        [DataMember]
        public string RoomName { get; set; }

        [DataMember]
        public Area Area { get; set; }
    }
}