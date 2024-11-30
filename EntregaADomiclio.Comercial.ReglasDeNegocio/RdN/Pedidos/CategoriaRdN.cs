using AutoMapper;
using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio.Pedidos;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN.Pedidos
{
    internal class CategoriaRdN : BaseRdN, ICategoriaRdN
    {
        public CategoriaRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public async Task<List<CategoriaDto>> ObtenerTodosAsync()
        {
            List<Categoria> entidades;
            List<CategoriaDto> dtos;

            entidades = await _repositorio.Categoria.ObtenerTodosAsync();
            dtos = _mapper.Map<List<CategoriaDto>>(entidades);

            return dtos;
        }
    }
}
