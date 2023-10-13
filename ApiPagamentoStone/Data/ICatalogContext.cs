using ApiPagamentoStone.Entities;
using MongoDB.Driver;

namespace ApiPagamentoStone.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Pedido> Pedido { get; }
    }
}
