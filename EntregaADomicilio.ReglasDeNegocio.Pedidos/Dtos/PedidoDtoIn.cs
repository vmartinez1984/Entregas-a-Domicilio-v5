using System.ComponentModel.DataAnnotations;

namespace EntregaADomicilio.Pedidos.Dtos
{
    public class PedidoDtoIn
    {        
        public string EncodedKey { get; set; }

        [Required]
        public List<PlatilloDtoIn> Platillos { get; set; }

        public string Nota { get; set; }
    }

    public class PlatilloDtoIn
    {
        public string EncodedKey { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }
    }

    public class PedidoDto
    {

    }
}
