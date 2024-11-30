using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomicilio.Repositorios.Repo
{
    internal class Repositorio : IRepositorio
    {
        public Repositorio(
            ICategoriaRepositorio categoria, 
            IPlatilloRepositorio platilloRepositorio,
            IPersonaRepositorio personaRepositorio
        )
        {
            Categoria = categoria;
            Platillo = platilloRepositorio;
            Persona = personaRepositorio;
        }

        public ICategoriaRepositorio Categoria { get; }

        public IPlatilloRepositorio Platillo {  get; }

        public IPersonaRepositorio Persona { get; }
    }
}