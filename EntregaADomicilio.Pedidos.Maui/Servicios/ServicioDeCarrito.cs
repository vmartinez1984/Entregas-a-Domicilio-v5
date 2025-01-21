using EntregaADomicilio.Core.Dtos.Pedidos;

namespace EntregaADomicilio.Pedidos.Maui.Servicios
{
    public class ServicioDeCarrito
    {
        public List<PlatilloDto> platillos = new List<PlatilloDto>();

        public ServicioDeCarrito()
        {
            
        }

        public void Agregar(PlatilloDto platillo)
        {
            this.platillos.Add(platillo);
        }

        public void Borrar(PlatilloDto platillo) { 
            this.platillos.Remove(platillo);
        }

        public List<PlatilloDto> ObtenerTodos() { 
            return this.platillos;
        }

    }
}
