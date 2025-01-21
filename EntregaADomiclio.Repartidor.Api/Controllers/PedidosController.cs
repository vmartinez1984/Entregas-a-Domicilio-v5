using EntregaADomicilio.Core.Repartidores.Dtos;
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
            List<PedidoDto> pedido;

            pedido = await _reglasDeNegocio.Pedido.ObtenerAsync();
            this.HttpContext.Response.Headers.Add("Total", pedido.Count.ToString());

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
            await _reglasDeNegocio.Pedido.PedidoEntregadoAsync(pedidoId);

            return Accepted();
        }

        /// <summary>
        /// Aceptar pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <returns></returns>
        [HttpPost("{pedidoId}/Aceptar")]
        public async Task<IActionResult> AceptarPedidoAsync(string pedidoId)
        {
            await _reglasDeNegocio.Pedido.AceptarPedidoAsync(ObtenerId(), pedidoId);

            return Accepted();
        }

        /// <summary>
        /// Pedidos que lleva en camino el repartidor
        /// </summary>
        /// <returns></returns>
        [HttpGet("EnCamino")]
        public async Task<IActionResult> ObtenerPedidosEnCaminoAsync()
        {
            List<PedidoDto> pedidoDtos;

            pedidoDtos = await _reglasDeNegocio.Pedido.ObtenerPedidosEnCaminoAsync(ObtenerId());
            this.HttpContext.Response.Headers.Add("Total", pedidoDtos.Count.ToString());

            return Ok(pedidoDtos);
        }
    }
}