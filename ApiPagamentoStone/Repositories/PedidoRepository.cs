using ApiPagamentoStone.Data;
using ApiPagamentoStone.Entities;
using MongoDB.Driver;

namespace ApiPagamentoStone.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ICatalogContext _catalogContext;
         public PedidoRepository(ICatalogContext catalogContext) 
        {
            _catalogContext = catalogContext;
        }

        public async Task CreatePedido(Pedido pedido)
        {
            await _catalogContext.Pedido.InsertOneAsync(pedido);
        }

        public async Task<bool> DeletePedido(string id)
        {
            FilterDefinition<Pedido> filter = Builders<Pedido>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _catalogContext.Pedido.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Pedido>> GetPedido()
        {
            return await _catalogContext.Pedido.Find(p => true).ToListAsync();
        }

        public async Task<Pedido> GetPedido(string id)
        {
            return await _catalogContext.Pedido.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            var updateResult = await _catalogContext.Pedido.ReplaceOneAsync(filter: g => g.Id == pedido.Id, replacement: pedido);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
