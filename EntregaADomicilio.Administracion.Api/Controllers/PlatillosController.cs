using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Administracion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : BaseEADController
    {
        public PlatillosController(IReglasDeNegocio repositorio) : base(repositorio)
        {
        }


        [HttpPost]
        public async Task<IActionResult> AgregarPlatilloAsync([FromForm]PlatilloDtoIn platillo)
        {
            PlatilloDto platillo1;

            platillo1 = await _reglasDeNegocio.Platillo.ObtenerPorIdAsync(platillo.EncodedKey);
            if (platillo1 != null)
                return Ok(platillo1);
            IdDto idDto;

            idDto = await _reglasDeNegocio.Platillo.AgregarAsync(platillo);

            return Created($"Platillos/{idDto.Id}", idDto);
        }


    }
}
