namespace EntregaADomicilio.Repartidores.Dtos
{
    public class IdDto
    {
        public string EncodedKey { get; set; }

        public int Id { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}
