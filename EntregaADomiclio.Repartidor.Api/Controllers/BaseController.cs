using EntregaADomicilio.Repartidores.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace EntregaADomicilio.Repartidor.Api.Controllers
{
    /// <summary>
    /// Clase que inicializa el repositorio
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Reglas de negocio
        /// </summary>
        public readonly UnitOfWork _reglasDeNegocio;

        /// <summary>
        /// Base
        /// </summary>
        /// <param name="repositorio"></param>
        public BaseController(UnitOfWork repositorio)
        {
            _reglasDeNegocio = repositorio;
        }

        /// <summary>
        /// Obtiene el RepartidorId de los claims
        /// </summary>
        /// <returns></returns>
        protected string ObtenerId()
        {           
            var claim = this.HttpContext.User.Claims.First(x => x.Type == "RepartidorId");            

            return claim.Value;
        }
    }
}
