﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BuildingService.Domain.Utility
{
    public class Sensor
    {
        public string SensorType { get; set; }
        public Coordinates Coordinates { get; set; }

    }
}