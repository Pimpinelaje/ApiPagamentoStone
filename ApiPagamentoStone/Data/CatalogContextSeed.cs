using ApiPagamentoStone.Entities;
using MongoDB.Driver;

namespace ApiPagamentoStone.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Pedido> pedidoCollection)
        {
            bool existPedido = pedidoCollection.Find(p => true).Any();
            if (!existPedido)
            {
                pedidoCollection.InsertManyAsync(MyPedido);
            }           
        }

        private static IEnumerable<Pedido> MyPedido
        {
            get
            {
                new Pedido()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Cliente = "Jefferson",
                    Itens = "Carro",
                    Valor = 20000.00M,
                    ValorTotal = 20000.00M,
                    Status = "Pendente"
                };
                new Pedido()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Cliente = "Matheus",
                    Itens = "Trator",
                    Valor = 30000.00M,
                    ValorTotal = 30000.00M,
                    Status = "Pendente"
                };
                new Pedido()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Cliente = "Giovanna",
                    Itens = "Moto",
                    Valor = 25000.00M,
                    ValorTotal = 25000.00M,
                    Status = "Pendente"
                };
            }            
        }
    }
}
