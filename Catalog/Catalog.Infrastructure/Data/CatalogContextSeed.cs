using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkProducts = productCollection.Find(b => true).Any();
            if (!checkProducts)
            {
                // FOR DOCKER CONTAINER
                string path = Path.Combine("Data", "SeedData", "products.json");
                var productsData = File.ReadAllText(path);

                // FOR LOCAL TESTING ONLY
                //var productsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        productCollection.InsertOneAsync(product);
                    }
                }
            }
        }
    }
}
