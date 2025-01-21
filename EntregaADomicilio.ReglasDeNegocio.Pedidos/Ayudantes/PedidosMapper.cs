using AutoMapper;
using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Pedidos.Dtos;

namespace EntregaADomicilio.Pedidos.Ayudantes
{
    internal class PedidosMapper : Profile
    {
        public PedidosMapper()
        {
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Platillo, PlatilloDto>();

            CreateMap<DireccionDtoIn, Direccion>();

            CreateMap<ClienteDtoIn, Persona>();

            CreateMap<Direccion, DireccionDto>();
            CreateMap<Persona, ClienteDto>();

            CreateMap<ClienteDtoUpd, Persona>();

            CreateMap<PlatilloDtoIn, PlatilloDePedido>();

            CreateMap<PlatilloDePedido, PlatilloDtoIn>();
            CreateMap<PedidoDtoIn, Pedido>();

            CreateMap<Platillo, PlatilloDePedido>();

            CreateMap<Pedido, PedidoDto>();
        }
    }
}