using EntregaADomicilio.Pedidos.Dtos;
using EntregaADomicilio.Pedidos.ReglasDeNegocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{
    /// <summary>
    /// Controlador de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cliente")]
    public class ClientesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositorio"></param>
        public ClientesController(PedidoUoW repositorio) : base(repositorio)
        {
        }

        /// <summary>
        /// Agregar cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <response code="201">IdDto</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AgregarCliente(ClienteDtoIn cliente)
        {
            ClienteDto cliente1;

            cliente1 = await _reglasDeNegocio.Cliente.ObtenerClientePorId(cliente.EncodedKey);
            if (cliente1 is not null)
                return Ok(cliente1);

            cliente1 = await _reglasDeNegocio.Cliente.ObtenerClientePorCorreo(cliente.Correo);
            if (cliente1 is not null)
                return BadRequest("Correo registrado previamente");

            IdDto idDto;

            idDto = await _reglasDeNegocio.Cliente.AgregarAsync(cliente);

            return Created(string.Empty, idDto);
        }

        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <param name="inicioDeSesion"></param>
        /// <response code="200">Token</response>
        /// <response code="404">Contraseña y/o correo incorrectos</response>
        [HttpPost("InicioDeSesiones")]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(InicioDeSesionDtoIn inicioDeSesion)
        {
            TokenDto token;

            token = await _reglasDeNegocio.Cliente.IniciarSesionAsync(inicioDeSesion);
            if (token == null)
                return NotFound(new { Mensaje = "Datos incorrectos", Fecha = DateTime.Now });

            return Ok(token);
        }

        /// <summary>
        /// Actualizar cliente
        /// </summary>
        /// <param name="clienteId"></param>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut("{clienteId}")]
        public async Task<IActionResult> ActualizarAsync(string clienteId, ClienteDtoUpd cliente)
        {
            await _reglasDeNegocio.Cliente.ActualizarAsync(clienteId, cliente);

            return Accepted();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">ClienteDto</response>
        /// <response code="404">No encontrado</response>
        [HttpGet]
        public async Task<IActionResult> ObtenerCliente()
        {
            ClienteDto cliente;

            cliente = await _reglasDeNegocio.Cliente.ObtenerClientePorId(ObtenerClienteId());
            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }
    }
}
