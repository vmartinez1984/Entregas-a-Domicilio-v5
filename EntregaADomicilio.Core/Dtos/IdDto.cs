namespace EntregaADomicilio.Core.Dtos
{
    public class IdDto
    {
        public string Id { get; set; }

        public string EncodedKey { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}
