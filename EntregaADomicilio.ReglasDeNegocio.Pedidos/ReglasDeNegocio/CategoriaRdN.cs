using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Pedidos.Dtos;

namespace EntregaADomicilio.Pedidos.ReglasDeNegocio
{
    public class CategoriaRdN : BaseRdN
    {
        public CategoriaRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public async Task<CategoriaDto> ObtenerPorIdAsync(string categoriaId)
        {
            CategoriaDto dto;
            Categoria entidad;

            entidad = await _repositorio.Categoria.ObtenerPorIdAsync(categoriaId);
            dto = _mapper.Map<CategoriaDto>(entidad);

            return dto;
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