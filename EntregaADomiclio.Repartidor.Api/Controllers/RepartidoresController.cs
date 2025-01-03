using EntregaADomicilio.Core.Repartidores.Dtos;
using EntregaADomicilio.Repartidores.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Repartidor.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]   
    public class RepartidoresController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositorio"></param>
        public RepartidoresController(UnitOfWork repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Incio de sesión
        /// </summary>
        /// <param name="inicioDeSesion"></param>
        /// <returns></returns>
        [HttpPost("IniciarSesiones")]
        public async Task<IActionResult> IniciarSesionAsync(InicioDeSesionDto inicioDeSesion)
        {
            TokenDto token;

            token = await _reglasDeNegocio.Repartidor.IniciarSesionAsync(inicioDeSesion);
            if (token == null)
                return NotFound(new { Mensaje = "Las credenciales no son validas" });

            return Ok(token);
        }


        [HttpPost("Contraseñas/Recuperar")]
        public  Task<IActionResult> RecuperarContraseñaAsync()
        {
            throw new NotImplementedException();
        }

    }
}
