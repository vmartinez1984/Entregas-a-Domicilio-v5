using EntregaADomicilio.Core.Dtos.Administracion;

namespace EntregaADomiclio.Administracion.ReglasDeNegocio
{
    public class PedidoRdN
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
