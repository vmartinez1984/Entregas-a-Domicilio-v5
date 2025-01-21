namespace EntregaADomicilio.Pedidos.Maui.Servicios
{
    public class Servicio
    {
        public ServicioDeCategoria Categoria { get; }

        public ServicioDePlatillo Platillo { get; }

        public ServicioDeConfiguracion Configuracion { get; }

        public Servicio(
            ServicioDeConfiguracion servicioDeConfiguracion,
            ServicioDePlatillo servicioDePlatillo,
            ServicioDeCategoria servicioDeCategoria
        )
        {
            Configuracion = servicioDeConfiguracion;
            Platillo = servicioDePlatillo;
            Categoria = servicioDeCategoria;
        }
    }
}