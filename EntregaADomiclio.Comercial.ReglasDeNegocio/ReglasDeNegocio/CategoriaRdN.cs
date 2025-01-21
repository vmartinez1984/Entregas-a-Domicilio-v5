using AutoMapper;
using EntregaADomicilio.Core.Dtos.Administracion;
using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomiclio.Administracion.ReglasDeNegocio
{
    public class CategoriaRdN : BaseRdN
    {
        private readonly IAlmacenDeArchivos _almacenDeArchivos;
        public CategoriaRdN(IRepositorio repositorio, IMapper mapper, IAlmacenDeArchivos almacenDeArchivos) : base(repositorio, mapper)
        {
            _almacenDeArchivos = almacenDeArchivos;
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
            if (categoria.FormFile != null)
                entidad.Archivo = await GuardarEnAlmacenAsync(categoria);
            id = new IdDto
            {
                Id = await _repositorio.Categoria.AgregarAsync(entidad),
                EncodedKey = categoria.EncodedKey
            };

            return id;
        }

        private async Task<Archivo> GuardarEnAlmacenAsync(CategoriaDtoIn platillo)
        {
            string aliasDelArchivo;
            string respuesta;
            Archivo archivo;

            aliasDelArchivo = $"{platillo.EncodedKey}{Path.GetExtension(platillo.FormFile.FileName)}";
            respuesta = await _almacenDeArchivos.Guardar("Categorias", aliasDelArchivo, platillo.FormFile);
            archivo = new Archivo
            {
                AliasDelArchivo = aliasDelArchivo,
                ContentType = platillo.FormFile.ContentType,
                NombreDelArchivo = platillo.FormFile.FileName,
                RutaDelArchivo = respuesta
            };

            return archivo;
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

        public async Task<byte[]> ObtenerImagenPorIdAsync(string categoriaId)
        {
            Categoria categoria;

            categoria = await _repositorio.Categoria.ObtenerPorIdAsync(categoriaId);

            return await _almacenDeArchivos.ObtenerBytes(categoria.Archivo.RutaDelArchivo);
        }

    }
}