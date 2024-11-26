using AutoMapper;
using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Entidades;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Ayudantes
{
    internal class Maper : Profile
    {
        public Maper()
        {
            CreateMap<CategoriaDtoIn, Categoria>();
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDtoUpd, Categoria>();
        }
    }
}
