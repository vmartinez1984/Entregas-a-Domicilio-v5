using EntregaADomicilio.Pedidos.Dtos;
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
    }
}