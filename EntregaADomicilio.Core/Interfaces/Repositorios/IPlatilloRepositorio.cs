using EntregaADomicilio.Core.Dtos;
using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IPlatilloRepositorio
    {
        Task<int> AgregarAsync(PlatilloDtoIn platillo);
        Task<Platillo> ObtenerPorIdAsync(string platilloId);
    }
}
