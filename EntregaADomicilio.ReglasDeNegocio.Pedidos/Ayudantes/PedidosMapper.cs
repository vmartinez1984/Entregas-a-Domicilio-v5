using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Pedidos.Dtos;

namespace EntregaADomicilio.Pedidos.Ayudantes
{
    internal class PedidosMapper: Profile
    {
        public PedidosMapper()
        {
            CreateMap<Categoria,CategoriaDto>();

            CreateMap<Platillo, PlatilloDto>();

            CreateMap<DireccionDtoIn, Direccion>();

            CreateMap<ClienteDtoIn, Persona>();

            CreateMap<Direccion, DireccionDto>();
            CreateMap<Persona, ClienteDto>();

            CreateMap<ClienteDtoUpd, Persona>();
        }
    }
}