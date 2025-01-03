namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class Servicio
    {
        public ServicioDeInicioDeSesion InicioDeSesion { get; }
        public ServicioDeConfiguracion Configuracion { get; }

        public Servicio(
            ServicioDeInicioDeSesion servicioDeInicioDeSesion,
            ServicioDeConfiguracion servicioDeConfiguracion
        )
        {
            InicioDeSesion = servicioDeInicioDeSesion;
            Configuracion = servicioDeConfiguracion;
        }
    }
}
