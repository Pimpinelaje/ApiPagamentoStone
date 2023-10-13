using ApiPagamentoStone.Entities;

namespace ApiPagamentoStone.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedido();
        Task<Pedido> GetPedido(string id);
        Task CreatePedido(Pedido pedido, Status status, Cliente cliente, Itens itens);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> CancelarPedido(string id);
    }
}
