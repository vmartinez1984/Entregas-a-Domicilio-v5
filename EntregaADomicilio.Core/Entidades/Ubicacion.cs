using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EntregaADomicilio.Core.Entidades
{
    public class Ubicacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string PedidoId { get; set; }

        public string RepartidorId { get; set; }

        public List<Coordenada> Coordenadas { get; set; }
        public string EncodedKey { get; set; }
    }

    public class Coordenada
    {        
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
        public string CoordenadasGps { get; set; }
        public int Id { get; set; }
    }
}
