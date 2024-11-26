using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class ClientesController : BaseController
    {
        public ClientesController(IReglasDeNegocio repositorio) : base(repositorio)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCliente(ClienteDtoIn cliente)
        {
            IdDto idDto;

            idDto = await _reglasDeNegocio.Cliente.AgregarAsync(cliente);

            return Ok(idDto);
        }

        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <param name="inicioDeSesion"></param>
        /// <response code="200">Token</response>
        /// <response code="404">Contraseña y/o correo incorrectos</response>
        [HttpPost("InicioDeSesiones")]
        public async Task<IActionResult> IniciarSesion(TokenDto inicioDeSesion)
        {
            TokenDto token;

            token = await _reglasDeNegocio.Cliente.IniciarSesionAsync(inicioDeSesion);
            if (token == null)
                return NotFound(new { Mensaje = "Datos incorrectos", Fecha= DateTime.Now });

            return Ok(token);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar(ClienteDtoIn cliente)
        {
            string clienteId;

            clienteId = ObtenerClienteId();

            return Accepted();
        }
              
        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <param name="inicioDeSesion"></param>
        /// <response code="200">Token</response>
        /// <response code="404">Contraseña y/o correo incorrectos</response>
        [HttpGet("{clienteId}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerId(string clienteId)
        {
            ClienteDto cliente;

            cliente = await _reglasDeNegocio.Cliente.ObtenerClientePorId(clienteId);

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCliente()
        {
            ClienteDto cliente;

            cliente = await _reglasDeNegocio.Cliente.ObtenerClientePorId(ObtenerClienteId());

            return Ok(cliente);
        }
    }
}
