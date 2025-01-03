namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class Servicio
    {
        public ServicioDeInicioDeSesion InicioDeSesion { get; }
        public ServicioDeConfiguracion Configuracion { get; }
        public ServicioDePedido Pedido { get; }

        public Servicio(
            ServicioDeInicioDeSesion servicioDeInicioDeSesion,
            ServicioDeConfiguracion servicioDeConfiguracion,
            ServicioDePedido servicioDePedido
        )
        {
            InicioDeSesion = servicioDeInicioDeSesion;
            Configuracion = servicioDeConfiguracion;
            Pedido = servicioDePedido;
        }
    }
}
