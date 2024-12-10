using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Repartidores.Dtos;

namespace EntregaADomicilio.Repartidores.Ayudantes
{
    internal class RepartidorMapers: Profile
    {
        public RepartidorMapers()
        {
            CreateMap<PlatilloDePedido, PlatilloDto>();
            CreateMap<Pedido, PedidoDto>();
        }
    }
}
