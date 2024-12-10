namespace EntregaADomicilio.Core.Dtos.Administracion
{
    public class IdDto
    {
        public string Id { get; set; }

        public string EncodedKey { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}
