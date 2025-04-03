using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IPlatilloRepositorio
    {
        Task ActualizarAsync(Platillo entidad);
        Task<int> AgregarAsync(Platillo platillo);
        Task<Platillo> BuscarAsync(string nombre);
        Task<Platillo> ObtenerPorIdAsync(string platilloId);
        Task<List<Platillo>> ObtenerTodosAsync(bool estaActivo = true);
        Task<List<Platillo>> ObtenerTodosPorCategoriaIdAsync(string categoriaId, bool estaActivo = true);
    }
}