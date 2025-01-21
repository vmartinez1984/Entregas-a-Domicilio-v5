using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Dtos.Pedidos
{
    public class PlatilloDto
    {
        public string Id { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public string EnlaceDeImagen { get; set; }
    }

    public static class Mapeador
    {
        public static PlatilloDto ToDto(this Platillo platillo)
        {
            return new PlatilloDto
            {
                Categoria = platillo.Categoria,
                Descripcion = platillo.Descripcion,
                Nombre = platillo.Nombre,
                Precio = (decimal)platillo.Precio,
                Id = platillo.Id.ToString()
            };
        }
    }
}
