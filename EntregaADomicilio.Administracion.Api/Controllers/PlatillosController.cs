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

      
    }
}
