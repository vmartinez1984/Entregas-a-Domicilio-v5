using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomicilio.Repositorios.Repo
{
    internal class Repositorio : IRepositorio
    {
        public Repositorio(ICategoriaRepositorio categoria, IPlatilloRepositorio platilloRepositorio)
        {
            Categoria = categoria;
            Platillo = platilloRepositorio;
        }

        public ICategoriaRepositorio Categoria { get; }

        public IPlatilloRepositorio Platillo {  get; }
    }
}
