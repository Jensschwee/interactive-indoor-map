using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingService
{
    public class Products
    {
        private Products() { }

        public static Products Instance { get; } = new Products();

        public List<Product> ProductList => products;

        public List<Product> products = new List<Product>()
        {
            new Product() {ProductID = 1, Name = "SomeProduct", CategoryName = "SomeCategory", Price = 10}
        };
    }
}