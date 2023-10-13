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

        public async Task CreatePedido(Pedido pedido, Status status, Cliente cliente, Itens itens)
        {
            try
            {
                var obj = new Pedido();
                obj.Id = Guid.NewGuid().ToString();
                obj.Cliente = cliente.Nome;
                obj.Itens = itens.Name;
                obj.IsPendente = true;
                obj.IsCancelado = false;
                obj.IsPago = false;
                obj.IsEstornado = false;
                obj.Valor = itens.Valor;

                await _catalogContext.Pedido.InsertOneAsync(obj);


            }
            catch (Exception f)
            {
                string msg = string.Concat("Ocorreu um erro ao salvar: " + f.Message);
                throw new ArgumentException(msg, f);
            }
        }

        public async Task<bool> CancelarPedido(string id)
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
