using ApiPagamentoStone.Entities;

namespace ApiPagamentoStone.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedido();
        Task<Pedido> GetPedido(string id);
        Task CreatePedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(string id);
    }
}
