using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN
{
    internal class PedidoRdN : IPedido
    {
        public Task<IdDto> AgregarAsync(string clienteId, PedidoDtoIn pedido)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> ObtenerPorIdAsync(string pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDto> ObtenerPorIdAsync(object encodedKey)
        {
            throw new NotImplementedException();
        }

        public Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(string clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
