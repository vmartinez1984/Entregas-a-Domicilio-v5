using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : BaseController
    {
        public CategoriasController(IReglasDeNegocio repositorio) : base(repositorio)
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
