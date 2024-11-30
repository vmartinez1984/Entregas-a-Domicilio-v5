using EntregaADomicilio.Pedidos.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Comercial.Api.Controllers
{    
    /// <summary>
    /// Base que inyecta el repositorio
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Reglas de negocio
        /// </summary>
        public readonly PedidoUoW _reglasDeNegocio;

        /// <summary>
        /// Base
        /// </summary>
        /// <param name="repositorio"></param>
        public BaseController(PedidoUoW repositorio)
        {
            _reglasDeNegocio = repositorio;
        }

        /// <summary>
        /// Obtiene el clienteId de los claims
        /// </summary>
        /// <returns></returns>
        protected string ObtenerClienteId()
        {
            //string clienteId;

            var claim = this.HttpContext.User.Claims.First(x => x.Type == "ClienteId");
            //clienteId = int.Parse(claim.Value);

            return claim.Value;
        }
    }
}