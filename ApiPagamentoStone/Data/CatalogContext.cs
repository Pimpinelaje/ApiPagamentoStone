using ApiPagamentoStone.Entities;
using MongoDB.Driver;

namespace ApiPagamentoStone.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration) 
        {
            var cliente = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            var database = cliente.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            Pedido = database.GetCollection<Pedido>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Pedido);
        }
        public IMongoCollection<Pedido> Pedido { get; }
    }
}
