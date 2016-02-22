using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BuildingService.Domain.Utility;

namespace BuildingService.Domain
{
    [DataContract]
    public class BuildingDimensions
    {
        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public List<FloorDimensons> Floors { get; set; }
    }
}