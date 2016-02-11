using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utility
{
    class WifiClient
    {
        public DeviceType DeviceType { get; set; }

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