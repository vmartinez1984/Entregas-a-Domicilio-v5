using AutoMapper;
using EntregaADomicilio.Core.Dtos.Administracion;
using EntregaADomicilio.Core.Entidades;

namespace EntregaADomiclio.Administracion.Ayudantes
{
    internal class PedidosMapper: Profile
    {
        public PedidosMapper()
        {
            CreateMap<Categoria,CategoriaDto>();
        }
    }
}
