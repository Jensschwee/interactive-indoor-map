using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BuildingService.Domain;

namespace BuildingService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBuildingService" in both code and config file together.
    [ServiceContract]
    public interface IBuildingService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/BuildingDimensions/{BuildingId}")]
        Building BuildingDimensions();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/SensorLocations/{BuildingId}")]
        Building SensorLocations();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/BuildingSensorData/{BuildingId}")]
        Building BuildingSensorData();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/FloorSensorData/{BuildingId}/{FloorLevel}")]
        Building FloorSensorData();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/RoomSensorData/{BuildingId}/{RoomName}")]
        Building RoomSensorData();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/WifiClients/{FloorLevel}")]
        Building WifiClients();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/StoreBuildingSensorData/")]
        Building StoreBuildingSensorData();
    }
}
