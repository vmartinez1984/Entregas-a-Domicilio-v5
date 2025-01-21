using AutoMapper;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Core.Interfaces.Almacenes;

namespace EntregaADomicilio.Pedidos.ReglasDeNegocio
{
    public class PlatilloRdN : BaseRdN
    {
        private readonly IAlmacenDeArchivos _almacenDeArchivos;

        public PlatilloRdN(
            IRepositorio repositorio,
            IMapper mapper,
            IAlmacenDeArchivos almacenDeArchivos
        ) : base(repositorio, mapper)
        {
            _almacenDeArchivos = almacenDeArchivos;
        }

        /// <summary>
        /// Buscar por nombre o ingredientes
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public async Task<PlatilloDto> BuscarAsync(string nombre)
        {
            Platillo platillo;

            platillo = await _repositorio.Platillo.BuscarAsync(nombre);

            return platillo.ToDto();
        }

        public async Task<byte[]> ObtenerImagenPorIdAsync(string platilloId)
        {
            Platillo platillo;

            platillo = await _repositorio.Platillo.ObtenerPorIdAsync(platilloId);

            return await _almacenDeArchivos.ObtenerBytes(platillo.Archivo.RutaDelArchivo);
        }

        public async Task<List<PlatilloDto>> ObtenerPorCategoriaIdAsync(string categoria)
        {
            List<PlatilloDto> dtos;
            List<Platillo> entidadades;

            entidadades = await _repositorio.Platillo.ObtenerTodosPorCategoriaIdAsync(categoria);
            dtos = _mapper.Map<List<PlatilloDto>>(entidadades);

            return dtos;
        }

        public async Task<PlatilloDto> ObtenerPorIdAsync(string platilloId)
        {
            PlatilloDto dto;
            Platillo entidad;

            entidad = await _repositorio.Platillo.ObtenerPorIdAsync(platilloId);
            dto = _mapper.Map<PlatilloDto>(entidad);

            return dto;
        }

        public async Task<List<PlatilloDto>> ObtenerTodosAsync()
        {
            List<PlatilloDto> dtos;
            List<Platillo> entidadades;

            entidadades = await _repositorio.Platillo.ObtenerTodosAsync();
            dtos = _mapper.Map<List<PlatilloDto>>(entidadades);

            return dtos;
        }
    }
}
