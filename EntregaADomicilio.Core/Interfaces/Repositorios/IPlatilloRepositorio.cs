using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IPlatilloRepositorio
    {
        Task ActualizarAsync(Platillo entidad);
        Task<int> AgregarAsync(Platillo platillo);
        Task<Platillo> ObtenerPorIdAsync(string platilloId);
        Task<List<Platillo>> ObtenerTodosAsync();
        Task<List<Platillo>> ObtenerTodosPorCategoriaIdAsync(string categoriaId);
    }
}