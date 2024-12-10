using AutoMapper;
using EntregaADomicilio.Core.Dtos.Administracion;
using EntregaADomicilio.Core.Entidades;

namespace EntregaADomiclio.Administracion.Ayudantes
{
    internal class Maper : Profile
    {
        public Maper()
        {
            CreateMap<CategoriaDtoIn, Categoria>();
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDtoUpd, Categoria>();

            CreateMap<PlatilloDtoIn, Platillo>();
            CreateMap<Platillo, PlatilloDto>();
            CreateMap<PlatilloDtoUpdate, Platillo>();

            CreateMap<DireccionDtoIn, Direccion>();

            CreateMap<ClienteDtoIn, Persona>();

            CreateMap<Direccion, DireccionDto>();
            CreateMap<Persona, ClienteDto>();

            CreateMap<ClienteDtoUpd, Persona>();
        }

       
    }
}