using EntregaADomicilio.Repartidores.Dtos;
using EntregaADomicilio.Repartidores.ReglasDeNegocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Repartidor.Api.Controllers
{
    /// <summary>
    /// Controlador de pedidos con autenticación
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Repartidor")]
    public class PedidosController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositorio"></param>
        public PedidosController(UnitOfWork repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Obtener pedido para entregar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerAsync()
        {
            PedidoDto pedido;            

            pedido = await _reglasDeNegocio.Repartidor.ObtenerAsync(ObtenerId());

            return Ok(pedido);
        }

        /// <summary>
        /// Pedido entregado
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpPost("{pedidoId}/Entregado")]
        public async Task<IActionResult> PedidoEntregadoAsync(string pedidoId)
        {
            await _reglasDeNegocio.Repartidor.PedidoEntregadoAsync(pedidoId);

            return Accepted();
        }

        /// <summary>
        /// ACeptar pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpPost("{pedidoId}/Aceptar")]
        public async Task<IActionResult> AceptarPedidoAsync(string pedidoId)
        {
            await _reglasDeNegocio.Repartidor.AceptarPedidoAsync(ObtenerId(), pedidoId);

            return Accepted();
        }      
    }
}
