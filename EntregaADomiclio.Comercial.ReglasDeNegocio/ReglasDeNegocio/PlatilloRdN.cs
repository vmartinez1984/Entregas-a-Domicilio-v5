using AutoMapper;
using EntregaADomicilio.Core.Dtos.Administracion;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomiclio.Administracion.ReglasDeNegocio
{
    public class PlatilloRdN : BaseRdN
    {
        private readonly IAlmacenDeArchivos _almacenDeArchivos;

        public PlatilloRdN(IRepositorio repositorio, IMapper mapper, IAlmacenDeArchivos almacenDeArchivos) : base(repositorio, mapper)
        {
            _almacenDeArchivos = almacenDeArchivos;
        }

        public async Task ActualizarAsync(string id, PlatilloDtoUpdate platillo)
        {
            Platillo entidad;

            entidad = await _repositorio.Platillo.ObtenerPorIdAsync(id);
            entidad = _mapper.Map(platillo, entidad);

            await _repositorio.Platillo.ActualizarAsync(entidad);
        }

        public async Task<IdDto> AgregarAsync(PlatilloDtoIn platillo)
        {
            Platillo entidad;
            int id;

            entidad = _mapper.Map<Platillo>(platillo);
            if (platillo.FormFile != null)
                entidad.Archivo = await GuardarEnAlmacenAsync(platillo);
            id = await _repositorio.Platillo.AgregarAsync(entidad);

            return new IdDto { EncodedKey = entidad.EncodedKey, Id = id.ToString() };
        }

        private async Task<Archivo> GuardarEnAlmacenAsync(PlatilloDtoIn platillo)
        {
            string aliasDelArchivo;
            string respuesta;
            Archivo archivo;

            aliasDelArchivo = $"{platillo.EncodedKey}{Path.GetExtension(platillo.FormFile.FileName)}";
            respuesta = await _almacenDeArchivos.Guardar("Platillos", aliasDelArchivo, platillo.FormFile);
            archivo = new Archivo
            {
                AliasDelArchivo= aliasDelArchivo,
                ContentType = platillo.FormFile.ContentType,
                NombreDelArchivo = platillo.FormFile.FileName,
                RutaDelArchivo = respuesta
            };

            return archivo;
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
