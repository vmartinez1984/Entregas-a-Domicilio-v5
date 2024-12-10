using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Pedidos.Dtos;

namespace EntregaADomicilio.Pedidos.ReglasDeNegocio
{
    public class PedidoRdN : BaseRdN
    {
        public PedidoRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public async Task<IdDto> AgregarAsync(string clienteId, PedidoDtoIn pedido)
        {
            Pedido pedido1;
            int id;

            pedido1 = _mapper.Map<Pedido>(pedido);
            pedido1.Cliente = await _repositorio.Persona.ObtenerPorIdAsync(clienteId);
            pedido1.Platillos = await ObtenerPlatillosAsync(pedido.Platillos);
            id = await _repositorio.Pedido.AgregarAsync(pedido1);

            return new IdDto
            {
                EncodedKey = pedido1.EncodedKey,
                Id = id
            };
        }

        private async Task<List<PlatilloDePedido>> ObtenerPlatillosAsync(List<PlatilloDtoIn> platillos)
        {
            List<PlatilloDePedido> lista = new List<PlatilloDePedido>();

            foreach (var platillo in platillos)
            {
                Platillo entidad;
                PlatilloDePedido platilloDePedido;

                entidad = await _repositorio.Platillo.ObtenerPorIdAsync(platillo.EncodedKey);
                platilloDePedido = _mapper.Map<PlatilloDePedido>(entidad);
                platilloDePedido.Nota = platillo.Nota;
                lista.Add(platilloDePedido);
            }

            return lista;
        }

        public async Task<PedidoDto> ObtenerPorIdAsync(string pedidoId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerPorIdAsync(pedidoId);

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<List<PedidoDto>> ObtenerTodosPorClienteIdAsync(string clienteId)
        {
            List<Pedido> pedidos;

            pedidos = await _repositorio.Pedido.ObtenerTodosPorClienteIdAsync(clienteId);

            return _mapper.Map<List<PedidoDto>>(pedidos);
        }

        public async Task<PedidoDto> ObtenerUltimoPedidoAsync(string clienteId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerUltimoPedidoAsync(clienteId);

            return _mapper.Map<PedidoDto>(pedido);
        }
    }
}
