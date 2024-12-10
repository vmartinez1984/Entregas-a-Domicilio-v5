using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IUbicacionRepositorio
    {
        Task ActualizarAsync(Ubicacion entidad);
        Task<int> AgregarAsync(Ubicacion item);
        Task<Ubicacion> ObtenerPorIdAsync(string ubicacionId);
        Task<Ubicacion> ObtenerPorPedidoIdAsync(string pedidoId);
    }
}
