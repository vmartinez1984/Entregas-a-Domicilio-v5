using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntregaADomicilio.Core.Entidades
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public string Nombre { get; set; }

        public bool EstaActivo { get; set; } = true;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
        public Archivo Archivo { get; set; }
    }
}