using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Administracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public  Task<IActionResult> AgregarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
