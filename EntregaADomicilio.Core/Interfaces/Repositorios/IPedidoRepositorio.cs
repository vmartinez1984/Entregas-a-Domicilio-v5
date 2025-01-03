using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IPedidoRepositorio
    {
        Task ActualizarAsync(Pedido pedido);
        Task<int> AgregarAsync(Pedido pedido);
        Task<List<Pedido>> ObtenerPedidosPreparadoAsync();
        Task<Pedido> ObtenerPorIdAsync(string pedidoId);
        Task<List<Pedido>> ObtenerTodosPorClienteIdAsync(string clienteId);
        Task<Pedido> ObtenerUltimoPedidoAsync(string clienteId);
    }
}
