using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : BaseController
    {
        public PlatillosController(IReglasDeNegocio repositorio) : base(repositorio)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(_reglasDeNegocio.Platillo.ObtenerTodosAsync());
        }

        [HttpGet("Categorias/{categoriaId}")]
        public async Task<IActionResult> ObtenerPorCategoriaIdAsync(string categoriaId)
        {
            return Ok(_reglasDeNegocio.Platillo.ObtenerPorCategoriaIdAsync(categoriaId));
        }

        [HttpGet("{platilloId}")]
        public async Task<IActionResult> ObtenerPorIdAsync(string platilloId)
        {
            PlatilloDto platillo;

            platillo = await _reglasDeNegocio.Platillo.ObtenerPorIdAsync(platilloId);
            if(platillo == null)
                return NotFound();

            return Ok(platillo);
        }

        /// <summary>
        /// Obtiene la imagen del platillo por id
        /// </summary>
        /// <param name="platilloId"></param>        
        [HttpGet("{platilloId}/Imagen")]
        public async Task<IActionResult> ObtenerImagenPorPlatilloId(string platilloId)
        {
            byte[] bytes;

            bytes = await _reglasDeNegocio.Platillo.ObtenerImagenPorIdAsync(platilloId);

            return File(bytes, "image/png");
        }

        /// <summary>
        /// Agregar un platillo al menu
        /// </summary>
        /// <param name="platillo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PlatilloDtoIn platillo)
        {
            IdDto id;
            bool existe;
            PlatilloDto platilloDto;

            existe = await _reglasDeNegocio.Categoria.ExisteAsync(platillo.Categoria);
            if (!existe)
            {
                this.ModelState.AddModelError(nameof(PlatilloDtoIn.Categoria), "No existe la categoria");

                return BadRequest();
            }
            //if (platillo.Id is not null)
            //{
            //    platilloDto = await _unitOfWork.Platillo.ObtenerPorId((Guid)platillo.Id);
            //    if (platilloDto is not null)
            //        return Ok(platilloDto);
            //}
            id = await _reglasDeNegocio.Platillo.AgregarAsync(platillo);

            return Created($"Platillos/{id}", new { Id = id });
        }

        /// <summary>
        /// No implementado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="platillo"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromForm] PlatilloDtoUpdate platillo)
        {
            await _reglasDeNegocio.Platillo.ActualizarAsync(id, platillo);

            return Accepted();
        }
    }
}
