using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Pedidos.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    /// <summary>
    /// Controlador de categorias
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repositorio"></param>
        public CategoriasController(PedidoUoW repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Obtener todas las categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CategoriaDto> categorias;

            categorias = await _reglasDeNegocio.Categoria.ObtenerTodosAsync();            

            return Ok(categorias);
        }

        /// <summary>
        /// Obtiene la imagen de la categoria por id
        /// </summary>
        /// <param name="categoriaId"></param>        
        [HttpGet("{categoriaId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(string categoriaId)
        {
            byte[] bytes;

            bytes = await _reglasDeNegocio.Categoria.ObtenerImagenPorIdAsync(categoriaId);

            return File(bytes, "image/png");
        }
    }
}