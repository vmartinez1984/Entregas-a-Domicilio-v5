using AutoMapper;
using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Core.Entidades;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Ayudantes
{
    internal class PedidosMapper: Profile
    {
        public PedidosMapper()
        {
            CreateMap<Categoria,CategoriaDto>();
        }
    }
}
