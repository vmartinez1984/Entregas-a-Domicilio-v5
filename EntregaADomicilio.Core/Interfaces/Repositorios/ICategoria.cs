using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface ICategoriaRepositorio
    {
        Task ActualizarAsync(Categoria entidad);
        Task<string> AgregarAsync(Categoria entidad);
        Task<bool> ExisteAsync(string categoria);
        Task<Categoria> ObtenerPorIdAsync(string categoriaId);
        Task<List<Categoria>> ObtenerTodosAsync();
    }
}
