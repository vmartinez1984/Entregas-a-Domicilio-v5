using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Administracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        [HttpGet("/Pedidos/{PedidoId}")]
        public async Task<IActionResult> ObtenerUbicacionDelPedidoId()
        {
            return Ok();
        }
    }
}
