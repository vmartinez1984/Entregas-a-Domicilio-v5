using AutoMapper;
using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.RdN
{
    internal class PlatilloRdN : BaseRdN, IPlatillo
    {
        private readonly IAlmacenDeArchivos _almacenDeArchivos;

        public PlatilloRdN(IRepositorio repositorio, IMapper mapper, IAlmacenDeArchivos almacenDeArchivos) : base(repositorio, mapper)
        {
            _almacenDeArchivos = almacenDeArchivos;
        }

        public Task ActualizarAsync(string id, PlatilloDtoUpdate platillo)
        {
            throw new NotImplementedException();
        }

        public async Task<IdDto> AgregarAsync(PlatilloDtoIn platillo)
        {
            Platillo entidad;
            int id;

            entidad = _mapper.Map<Platillo>(platillo);
            if (platillo.FormFile != null)
                entidad.Archivo = await GuardarEnAlmacenAsync(platillo);
            id = await _repositorio.Platillo.AgregarAsync(platillo);

            return new IdDto { EncodedKey = entidad.EncodedKey, Id = id.ToString() };
        }

        private async Task<Archivo> GuardarEnAlmacenAsync(PlatilloDtoIn platillo)
        {
            string aliasDelArchivo;
            string respuesta;

            aliasDelArchivo = $"{platillo.EncodedKey}{Path.GetExtension(platillo.FormFile.FileName)}";
            respuesta = await _almacenDeArchivos.Guardar("Platillos", aliasDelArchivo, platillo.FormFile);

            throw new NotImplementedException();
        }

        public Task<byte[]> ObtenerImagenPorIdAsync(string platilloId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaDto>> ObtenerPorCategoriaIdAsync(string categoriaId)
        {
            throw new NotImplementedException();
        }

        public async Task<PlatilloDto> ObtenerPorIdAsync(string platilloId)
        {
            PlatilloDto dto;
            Platillo entidad;

            entidad = await _repositorio.Platillo.ObtenerPorIdAsync(platilloId);
            dto = _mapper.Map<PlatilloDto>(entidad);

            return dto;
        }

        public Task<List<CategoriaDto>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
