using AutoMapper;
using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomicilio.Pedidos.ReglasDeNegocio
{
    public class CategoriaRdN : BaseRdN
    {
        private readonly IAlmacenDeArchivos almacenDeArchivos;

        public CategoriaRdN(IRepositorio repositorio, IMapper mapper, IAlmacenDeArchivos almacenDeArchivos) : base(repositorio, mapper)
        {
            this.almacenDeArchivos = almacenDeArchivos;
        }

        public async Task<byte[]> ObtenerImagenPorIdAsync(string categoriaId)
        {
            Categoria categoria;
            byte[] bytes;

            categoria = await _repositorio.Categoria.ObtenerPorIdAsync(categoriaId);
            bytes = await almacenDeArchivos.ObtenerBytes(categoria.Archivo.RutaDelArchivo);

            return bytes;
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