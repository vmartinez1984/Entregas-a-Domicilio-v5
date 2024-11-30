using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EntregaADomicilio.Core.Dtos.Administracion
{
    public class PlatilloDto
    {
        public string Id { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool EstaActivo { get; set; }
    }

    public class PlatilloDtoIn
    {
        [Required]
        public string EncodedKey { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        //[Required]
        public IFormFile FormFile { get; set; }

        [Required]
        public string Categoria { get; set; }
    }

    public class PlatilloDtoUpdate
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public IFormFile FormFile { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public bool EstaActivo { get; set; }
    }
}
