using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomicilio.Repositorios.Repo
{
    internal class Repositorio : IRepositorio
    {
        public Repositorio(ICategoria categoria)
        {
            Categoria = categoria;
        }

        public ICategoria Categoria { get; }
    }
}
