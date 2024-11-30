using AutoMapper;
using EntregaADomicilio.Pedidos.Dtos;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomicilio.Pedidos.ReglasDeNegocio
{
    public class PlatilloRdN: BaseRdN
    {
        //private readonly IAlmacenDeArchivos _almacenDeArchivos;

        public PlatilloRdN(
            IRepositorio repositorio, 
            IMapper mapper
            //IAlmacenDeArchivos almacenDeArchivos
        ) : base(repositorio, mapper)
        {
            //_almacenDeArchivos = almacenDeArchivos;
        }
       
        public Task<byte[]> ObtenerImagenPorIdAsync(string platilloId)
        {
            throw new NotImplementedException();
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
