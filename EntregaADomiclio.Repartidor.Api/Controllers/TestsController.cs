using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Repartidor.Api.Controllers
{
    /// <summary>
    /// Contralador para la pruebas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        /// <summary>
        /// Hola mundo
        /// </summary>
        /// <param name="saludo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult HolaMundo(string saludo = null)
        {
            if (string.IsNullOrEmpty(saludo))
                return Ok(new { Mensaje = "Hola mundo" });

            return Ok(new { Mensaje = saludo });
        }
    }

}
