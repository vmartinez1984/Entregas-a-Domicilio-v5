using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Administracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidoresController : ControllerBase
    {
        /// <summary>
        /// Obtener la lista de categorias
        /// </summary>
        /// <response code="200">List<CategoriaDto>></response>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() => Ok();

        /// <summary>
        /// Obtener repartidor por id
        /// </summary>
        /// <param name="repartidorId"></param>
        /// <response code="404">No encontrado</response>
        /// <response code="200">CategoriaDto</response>
        [HttpGet("{repartidorId}")]
        public async Task<IActionResult> ObtenerPorId(string repartidorId)
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAsync()
        {            

            return Created();
        }

        [HttpPut("{repartidorId}")]
        public async Task<IActionResult> ActualizarAsync(string repartidorId)
        {
            

            return Accepted();
        }
    }
}
