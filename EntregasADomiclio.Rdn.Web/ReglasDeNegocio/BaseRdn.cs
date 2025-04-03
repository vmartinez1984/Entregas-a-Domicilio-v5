using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregasADomicilio.Web.ReglasDeNegocio
{
    public class BaseRdn
    {
        public readonly IRepositorio _repositorio;

        public BaseRdn(IRepositorio repositorio)
        {
            _repositorio = repositorio;            
        }
    }
}
