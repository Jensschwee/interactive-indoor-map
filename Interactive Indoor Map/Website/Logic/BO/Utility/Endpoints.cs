using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Website.Logic.BO.Utility
{
    public class Endpoints
    {
        private string _smapEndpontsJson;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SmapEndpontsJson
        {
            get { return _smapEndpontsJson; }
            set { _smapEndpontsJson = value; }
        }

        public Dictionary<string, SensorType> SmapEndponts
        {
            get { return JsonConvert.DeserializeObject<Dictionary<string, SensorType>>(SmapEndpontsJson); }
            set { SmapEndpontsJson = JsonConvert.SerializeObject(value); }
        }
        public string WifiEndpoint { get; set; }
    }
}