using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BuildingService
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int Price { get; set; }
    }
}