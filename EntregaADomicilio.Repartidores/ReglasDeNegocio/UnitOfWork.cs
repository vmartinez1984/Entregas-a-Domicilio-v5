namespace EntregaADomicilio.Repartidores.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public RepartidorRdN Repartidor { get; }

        public UbicacionRdN Ubicacion { get; }

        public UnitOfWork(
            RepartidorRdN repartidorRdN,
            UbicacionRdN ubicacionRdN
        )
        {
            Repartidor = repartidorRdN;
            Ubicacion = ubicacionRdN;
        }
    }
}
