namespace EntregaADomicilio.Core.Dtos
{
    public class CategoriaDto
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string EncodedKey { get; set; }
    }

    public class CategoriaDtoIn
    {
        public string Nombre { get; set; }

        public string EncodedKey { get; set; }
    }

}