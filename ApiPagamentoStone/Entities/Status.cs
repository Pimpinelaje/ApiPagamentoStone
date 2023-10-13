using MongoDB.Bson.Serialization.Attributes;

namespace ApiPagamentoStone.Entities
{
    public class Status
    {
        [BsonElement("Name")]
        public bool IsPendente { get; set; }
        public bool IsPago { get; set; }
        public bool IsCancelado { get; set; }
        public bool IsEstornado { get; set; }
    }
}
