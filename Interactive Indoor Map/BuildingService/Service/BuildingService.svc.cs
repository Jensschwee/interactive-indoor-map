using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BuildingService.Domain;

namespace BuildingService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BuildingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BuildingService.svc or BuildingService.svc.cs at the Solution Explorer and start debugging.
    public class BuildingService : IBuildingService
    {
        public Building GetBuildingData()
        {
            throw new NotImplementedException();
        }

        public Building GetFloorLevelNeg1Data()
        {
            throw new NotImplementedException();
        }

        public Building GetFloorLevel0Data()
        {
            throw new NotImplementedException();
        }

        public Building GetFloorLevel1Data()
        {
            throw new NotImplementedException();
        }

        public Building GetFloorLevel2Data()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductList()
        {
            return Products.Instance.ProductList;
        }
    }
}
