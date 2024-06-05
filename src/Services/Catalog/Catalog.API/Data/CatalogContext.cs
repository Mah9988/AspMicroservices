using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
                            // get setting from appsetting.json file 
        public CatalogContext(IConfiguration configuration)
        {
            // connect to mongo database
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            // seed default data : 
            CatalogContextSeed.seedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
