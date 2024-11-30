using System.ComponentModel.DataAnnotations;

namespace EntregaADomicilio.Pedidos.Dtos
{
    public class ClienteDtoUpd
    {       
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Telefono { get; set; }

        [Required]
        public DireccionDtoIn Direccion { get; set; }    
    }

    public class ClienteDtoIn
    {
        [Required]
        public string EncodedKey { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Telefono { get; set; }

        [Required]
        public DireccionDtoIn Direccion { get; set; }
    }

    public class ClienteDto
    {
        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Contrasenia { get; set; }

        public string Telefono { get; set; }

        public DireccionDto Direccion { get; set; }
    }

    public class DireccionDtoIn
    {
        [Required]
        public string CalleYNumero { get; set; }

        [Required]
        public string Referencia { get; set; }

        [Required]
        public string CoordenadasGps { get; set; }

        [Required]
        public string Colonia { get; set; }

        [Required]
        public string Alcaldia { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string CodigoPostal { get; set; }
    }

    public class DireccionDto
    {
        public int Id { get; set; }

        public string CalleYNumero { get; set; }

        public string Referencia { get; set; }


        public string CoordenadasGps { get; set; }


        public string Colonia { get; set; }


        public string Alcaldia { get; set; }


        public string Estado { get; set; }


        public string CodigoPostal { get; set; }
    }
}
