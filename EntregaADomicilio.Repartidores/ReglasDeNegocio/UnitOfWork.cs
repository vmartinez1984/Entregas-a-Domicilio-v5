namespace EntregaADomicilio.Repartidores.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public RepartidorRdN Repartidor { get; }

        public UbicacionRdN Ubicacion { get; }

        public PedidoRdN Pedido { get; }

        public UnitOfWork(
            RepartidorRdN repartidorRdN,
            UbicacionRdN ubicacionRdN,
            PedidoRdN pedidoRdN
        )
        {
            Repartidor = repartidorRdN;
            Ubicacion = ubicacionRdN;
            Pedido = pedidoRdN;
        }
    }
}
