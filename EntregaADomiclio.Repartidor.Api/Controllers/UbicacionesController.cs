using EntregaADomicilio.Repartidores.Dtos;
using EntregaADomicilio.Repartidores.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Repartidor.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositorio"></param>
        public UbicacionesController(UnitOfWork repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <param name="ubicacion"></param>
        /// <returns></returns>
        [HttpPost("Pedidos/{pedidoId}")]
        public async Task<IActionResult> AgregarUbicacionAsync(string pedidoId, UbicacionDto ubicacion)
        {
            IdDto idDto;
            
            idDto = await _reglasDeNegocio.Ubicacion.AgregarAsync(ObtenerId(), pedidoId, ubicacion);

            return Ok(idDto);
        }
    }
}
