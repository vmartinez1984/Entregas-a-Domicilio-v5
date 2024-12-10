

namespace EntregaADomiclio.Administracion.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public UnitOfWork(
            CategoriaRdN categoriaRdN,
            PlatilloRdN platillo,
            ClienteRdN cliente,
            PedidoRdN pedido 
        )
        {
            Categoria = categoriaRdN;
            Platillo = platillo;
            Cliente = cliente;
            Pedido = pedido;
        }

        public CategoriaRdN Categoria { get; }

        public PlatilloRdN Platillo { get; }

        public ClienteRdN Cliente { get; }

        public PedidoRdN Pedido { get; }
    }
}