using EntregaADomicilio.Pedidos.Dtos;
using EntregaADomicilio.Pedidos.ReglasDeNegocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositorio"></param>
        public PedidosController(PedidoUoW repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Registrar pedido
        /// </summary>
        /// <param name="pedido"></param>        
        /// <response code="202"></response>
        [HttpPost]
        [ProducesResponseType(typeof(IdDto), 202)]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        public async Task<IActionResult> AgregarPedido(PedidoDtoIn pedido)
        {
            PedidoDto pedidoDto;

            pedidoDto = await _reglasDeNegocio.Pedido.ObtenerPorIdAsync(pedido.EncodedKey);
            if (pedidoDto is not null)
                return Ok(pedidoDto);

            IdDto id;

            string clienteId = ObtenerClienteId();
            id = await _reglasDeNegocio.Pedido.AgregarAsync(clienteId, pedido);

            return Created($"Pedidos/{id.Id}", id);
        }

        /// <summary>
        /// Obtener el último pedido
        /// </summary>        
        /// <returns></returns>
        [HttpGet("Ultimo")]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]        
        public async Task<IActionResult> ObtenerUltimoPedidoAsync()
        {
            PedidoDto pedido;

            pedido = await _reglasDeNegocio.Pedido.ObtenerUltimoPedidoAsync(ObtenerClienteId());
            if (pedido is null)
                return NotFound();

            return Ok(pedido);
        }

        /// <summary>
        /// Obtiene la lista de pedidos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(PedidoDto), 200)]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
        public async Task<IActionResult> ObtenerTodosAsync()
        {
            List<PedidoDto> pedidos;
            string clienteId;

            clienteId = ObtenerClienteId();
            pedidos = await _reglasDeNegocio.Pedido.ObtenerTodosPorClienteIdAsync(clienteId);

            return Ok(pedidos);
        }
    }
}
