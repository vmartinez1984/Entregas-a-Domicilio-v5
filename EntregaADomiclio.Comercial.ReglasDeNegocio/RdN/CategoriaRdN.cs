using AutoMapper;
using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN
{
    internal class CategoriaRdN : BaseRdN, ICategoriaRdN
    {
        public CategoriaRdN(IRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        public async Task ActualizarAsync(string categoriaId, CategoriaDtoUpd categoriaDtoIn)
        {
            Categoria categoria;

            categoria = await _repositorio.Categoria.ObtenerPorIdAsync(categoriaId);
            categoria = _mapper.Map(categoriaDtoIn, categoria);

            await _repositorio.Categoria.ActualizarAsync(categoria);
        }

        public async Task<IdDto> AgregarAsync(CategoriaDtoIn categoria)
        {
            Categoria entidad;
            IdDto id;

            entidad = _mapper.Map<Categoria>(categoria);
            id = new IdDto
            {
                Id = await _repositorio.Categoria.AgregarAsync(entidad),
                EncodedKey = categoria.EncodedKey
            };

            return id;
        }

        public async Task BorrarAsync(string categoriaId)
        {
            Categoria entidad;

            entidad = await _repositorio.Categoria.ObtenerPorIdAsync(categoriaId);
            entidad.EstaActivo = false;

            await _repositorio.Categoria.ActualizarAsync(entidad);
        }

        public async Task<bool> ExisteAsync(string categoria) => await _repositorio.Categoria.ExisteAsync(categoria);


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