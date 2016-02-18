using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingService.Domain.Utility
{
    public class WifiClient
    {
        public DeviceType DeviceType { get; set; }

        public Coordinates Coordinates { get; set; }

        public WifiClient(string macAddress)
        {
            if (macAddress.ToString().Equals("Something"))
            {
                DeviceType = DeviceType.Laptop;
            }
            else if (macAddress.ToString().Equals("Something Else"))
            {
                DeviceType = DeviceType.SmartPhone;
            }
        }
    }
}