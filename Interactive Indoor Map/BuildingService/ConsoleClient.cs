using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using BuildingService.Service;

namespace BuildingService
{
    public class ConsoleClient
    {
        EndpointAddress ep = new EndpointAddress("http://localhost:8080/");

        IBuildingService proxy = new ChannelFactory<IBuil>.
    }
}