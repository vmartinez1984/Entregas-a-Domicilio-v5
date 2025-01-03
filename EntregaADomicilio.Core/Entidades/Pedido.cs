using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using EntregaADomicilio.Core.Constantes;

namespace EntregaADomicilio.Core.Entidades
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public List<PlatilloDePedido> Platillos { get; set; }

        public double Total { get { return Platillos.Sum(x => x.Precio); } }

        public string Nota { get; set; }

        public string Estado { get; set; } = EstadoDelPedido.Registrado;

        public Dictionary<string,DateTime> Estados { get; set; } = new Dictionary<string, DateTime>();

        public Persona Cliente { get; set; }

        public string RepartidorId { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public DateTime FechaDeActualizacion { get; set; } = DateTime.Now;
    }
}