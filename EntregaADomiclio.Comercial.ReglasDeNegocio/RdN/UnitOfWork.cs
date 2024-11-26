using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Bl
{
    public class UnitOfWork : IReglasDeNegocio
    {
        public UnitOfWork(
            ICategoriaRdN categoriaRdN,
            IPlatillo platillo,
            ICliente cliente,
            IPedido pedido 
        )
        {
            Categoria = categoriaRdN;
            Platillo = platillo;
            Cliente = cliente;
            Pedido = pedido;
        }

        public ICategoriaRdN Categoria { get; }

        public IPlatillo Platillo { get; }

        public ICliente Cliente { get; }

        public IPedido Pedido { get; }
    }
}