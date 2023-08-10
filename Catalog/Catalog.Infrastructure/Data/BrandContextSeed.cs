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
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();
            if (!checkBrands)
            {
                // FOR DOCKER CONTAINER
                string path = Path.Combine("Data", "SeedData", "brands.json");
                var brandsData = File.ReadAllText(path);

                // FOR LOCAL TESTING ONLY
                //var brandsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null)
                {
                    foreach (var brand in brands)
                    {
                        brandCollection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}
