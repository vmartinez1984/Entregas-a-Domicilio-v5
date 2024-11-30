using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EntregaADomicilio.Core.Entidades
{
    public class EntidadBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public bool EstaActivo { get; set; } = true;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}