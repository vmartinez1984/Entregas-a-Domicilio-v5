namespace EntregaADomicilio.Core.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public List<PlatilloDePedido> Platillos { get; set; }

        public double Total { get { return Platillos.Sum(x => x.Precio); } }

        public string Nota { get; set; }

        public string Estado { get; set; } = "Registrado";

        public Persona Cliente { get; set; }


        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}