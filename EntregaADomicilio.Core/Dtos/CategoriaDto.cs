using System.ComponentModel.DataAnnotations;

namespace EntregaADomicilio.Core.Dtos
{
    public class CategoriaDto
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string EncodedKey { get; set; }

        public bool EstaActivo { get; set; }
    }

    public class CategoriaDtoIn
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string EncodedKey { get; set; }
    }

    public class CategoriaDtoUpd
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public bool EstaActivo { get; set; }
    }
}