using MongoDB.Bson.Serialization.Attributes;

namespace ApiPagamentoStone.Entities
{
    public class Pedido : Status
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Cliente { get; set; }
        public string Itens { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Status { get; set; }
    }
}
