using EntregaADomicilio.Core.Dtos;

namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface IPedido
    {
        Task<IdDto> AgregarAsync(string clienteId, PedidoDtoIn pedido);
        Task<PedidoDto> ObtenerPorIdAsync(string pedidoId);
        Task<PedidoDto> ObtenerPorIdAsync(object encodedKey);
        Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(string clienteId);
    }
}
