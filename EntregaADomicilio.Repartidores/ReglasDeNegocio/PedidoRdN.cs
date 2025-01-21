using AutoMapper;
using EntregaADomicilio.Core.Constantes;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Core.Repartidores.Dtos;

namespace EntregaADomicilio.Repartidores.ReglasDeNegocio
{
    public class PedidoRdN : BaseRdN
    {
        public PedidoRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public async Task<List<PedidoDto>> ObtenerAsync()
        {
            List<Pedido> pedido;

            pedido = await _repositorio.Pedido.ObtenerPedidosPreparadoAsync();

            return _mapper.Map<List<PedidoDto>>(pedido);
        }

        public async Task<List<PedidoDto>> ObtenerPedidosEnCaminoAsync(string repartidorId)
        {
            List<Pedido> pedido;

            pedido = await _repositorio.Pedido.ObtenerPedidosPorEstadoYRepartidorId(repartidorId, EstadoDelPedido.EnCamino);

            return _mapper.Map<List<PedidoDto>>(pedido);
        }

        public async Task PedidoEntregadoAsync(string pedidoId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerPorIdAsync(pedidoId);
            pedido.Estado = EstadoDelPedido.Entregado;
            pedido.FechaDeActualizacion = DateTime.Now;

            await _repositorio.Pedido.ActualizarAsync(pedido);
        }

        public async Task AceptarPedidoAsync(string repartidorID, string pedidoId)
        {
            Pedido pedido;

            pedido = await _repositorio.Pedido.ObtenerPorIdAsync(pedidoId);
            pedido.RepartidorId = repartidorID;
            pedido.Estado = EstadoDelPedido.EnCamino;
            pedido.Estados.Add(EstadoDelPedido.EnCamino, DateTime.Now);
            pedido.FechaDeActualizacion = DateTime.Now;

            await _repositorio.Pedido.ActualizarAsync(pedido);
        }
        
    }
}
