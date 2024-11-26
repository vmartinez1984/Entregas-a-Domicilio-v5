using EntregaADomicilio.Core.Entidades;

namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface ICategoria
    {
        Task<List<Categoria>> ObtenerTodosAsync();
    }
}
