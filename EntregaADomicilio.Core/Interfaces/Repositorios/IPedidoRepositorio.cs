using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IPedidoRepositorio
    {
        Task<int> AgregarAsync(Pedido pedido);
        Task<Pedido> ObtenerPorIdAsync(string pedidoId);
    }
}
