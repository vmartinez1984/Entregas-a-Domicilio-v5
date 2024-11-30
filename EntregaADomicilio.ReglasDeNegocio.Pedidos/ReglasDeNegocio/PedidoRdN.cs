using AutoMapper;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Pedidos.Dtos;

namespace EntregaADomicilio.Pedidos.ReglasDeNegocio
{
    public class PedidoRdN : BaseRdN
    {
        public PedidoRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

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
