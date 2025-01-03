using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Repartidores.Dtos;

namespace EntregaADomicilio.Repartidores.Ayudantes
{
    internal class RepartidorMapers : Profile
    {
        public RepartidorMapers()
        {
            CreateMap<PlatilloDePedido, PlatilloDto>();
            CreateMap<Direccion, DireccionDto>();
            CreateMap<Persona, ClienteDto>()
                .ForMember(
                    destino => destino.Direccion,
                    mapeo => mapeo.MapFrom(
                        origen => origen.Direcciones.FirstOrDefault(x => x.EsLaPrincipal)
                    )
                )
                .ForMember(
                    destino => destino.NombreCompleto,
                    mapeo => mapeo.MapFrom(
                        origen => $"{origen.Nombre} {origen.Apellidos}"
                    )
                )
                ;

            CreateMap<Pedido, PedidoDto>();
        }
    }
}
