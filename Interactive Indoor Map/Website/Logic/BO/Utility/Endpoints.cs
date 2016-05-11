using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class Endpoints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Dictionary <string, SensorType> SmapEndponts { get; set; }
        public string WifiEndpoint { get; set; }
    }
}