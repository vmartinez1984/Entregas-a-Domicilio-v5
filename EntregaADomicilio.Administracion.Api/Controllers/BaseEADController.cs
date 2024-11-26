using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Administracion.Api.Controllers
{
    public class BaseEADController : ControllerBase
    {
        public readonly IReglasDeNegocio _reglasDeNegocio;

        public BaseEADController(IReglasDeNegocio repositorio)
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