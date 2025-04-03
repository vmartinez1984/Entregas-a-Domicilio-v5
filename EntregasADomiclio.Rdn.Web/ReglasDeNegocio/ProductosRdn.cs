using EntregaADomicilio.Core.Entidades;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregasADomicilio.Web.Dtos;
using EntregasADomiclio.Web.Ayudantes;

namespace EntregasADomicilio.Web.ReglasDeNegocio
{
    public class ProductosRdn : BaseRdn
    {
        private readonly IAlmacenDeArchivos _almacenDeArchivos;
        public ProductosRdn(
            IRepositorio repositorio
            , IAlmacenDeArchivos almacenDeArchivos
        ) : base(repositorio)
        {
            _almacenDeArchivos = almacenDeArchivos;
        }

        public async Task<List<ProductoDto>> ObtenerAsync()
        {
            List<Platillo> productos;

            productos = await _repositorio.Platillo.ObtenerTodosAsync();

            return productos.ToDtos();
        }

        /// <summary>
        /// OBtener lista de productos por categoriaId
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <returns></returns>
        public async Task<List<ProductoDto>> ObtenerAsync(string categoriaId)
        {
            List<Platillo> productos;

            if (categoriaId == null)
                productos = await _repositorio.Platillo.ObtenerTodosAsync();
            else
                productos = await _repositorio.Platillo.ObtenerTodosPorCategoriaIdAsync(categoriaId);

            return productos.ToDtos();
        }

        public async Task<byte[]> ObtenerImagenPorIdAsync(string platilloId)
        {
            Platillo platillo;
            byte[] bytes;

            platillo = await _repositorio.Platillo.ObtenerPorIdAsync(platilloId);
            bytes = await _almacenDeArchivos.ObtenerBytes(platillo.Archivo.RutaDelArchivo);

            return bytes;
        }
    }
}
