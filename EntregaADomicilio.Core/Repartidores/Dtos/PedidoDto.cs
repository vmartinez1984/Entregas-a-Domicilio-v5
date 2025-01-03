namespace EntregaADomicilio.Core.Repartidores.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public List<PlatilloDto> Platillos { get; set; }

        public double Total { get; set; }

        public string Nota { get; set; }

        public string Estado { get; set; }

        public ClienteDto Cliente { get; set; }

        public DateTime FechaDeRegistro { get; set; }
    }
}
