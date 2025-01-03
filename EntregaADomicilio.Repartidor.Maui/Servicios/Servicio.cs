namespace EntregaADomicilio.Repartidor.Maui.Servicios
{
    public class Servicio
    {
        public ServicioDeInicioDeSesion InicioDeSesion { get; }

        public Servicio(
            ServicioDeInicioDeSesion servicioDeInicioDeSesion
        )
        {
            InicioDeSesion = servicioDeInicioDeSesion;    
        }
    }
}
