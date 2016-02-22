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
            //Denne metode skal lave et kald til DB som giver os objekterne til bygningen, disse skal derefter bruges af de andre metoder.
            /*using (DBContext context = new DBContext())
            {
                //create building with DB data as input and return it
            }*/
            throw new NotImplementedException();
        }

        public Building GetCellarFloorLevel()
        {
            //sorter bygningsobjekterne så der kun er til de ene niveau.
            //Opret forbindelse til sensor api, hvis dette ikke kan lade sig gøre så returner resultat fra DB
            //Ændrer objekt data efter hvad input fra sensor api er
            //returner dette
            throw new NotImplementedException();
        }

        public Building GetGroundFloorData()
        {
            throw new NotImplementedException();
        }

        public Building GetFirstFloorData()
        {
            throw new NotImplementedException();
        }

        public Building GetSecondFloorData()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductList()
        {
            return Products.Instance.ProductList;
        }
    }
}
