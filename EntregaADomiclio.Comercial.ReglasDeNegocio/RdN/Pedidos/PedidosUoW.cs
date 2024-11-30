

using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio.Pedidos;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN.Pedidos
{
    public class PedidosUoW : IPedidosUoW
    {
        public ICategoriaRdN Categoria { get; }

        public PedidosUoW(ICategoriaRdN categoriaRdN)
        {
            Categoria = categoriaRdN;
        }
    }
}