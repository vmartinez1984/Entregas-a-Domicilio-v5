using System.ComponentModel.DataAnnotations;

namespace EntregaADomicilio.Repartidores.Dtos
{
    public class UbicacionDto
    {   
        [Required]
        public string CoordenadasGps { get; set; }
    }
}
