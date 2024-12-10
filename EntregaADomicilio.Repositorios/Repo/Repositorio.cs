using EntregaADomicilio.Core.Interfaces.Repositorios;

namespace EntregaADomicilio.Repositorios.Repo
{
    internal class Repositorio : IRepositorio
    {
        public Repositorio(
            ICategoriaRepositorio categoria, 
            IPlatilloRepositorio platilloRepositorio,
            IPersonaRepositorio personaRepositorio,
            IPedidoRepositorio pedidoRepositorio,
            IUbicacionRepositorio ubicacionRepositorio
        )
        {
            Categoria = categoria;
            Platillo = platilloRepositorio;
            Persona = personaRepositorio;
            Pedido = pedidoRepositorio;
            Ubicacion = ubicacionRepositorio;
        }
        public IUbicacionRepositorio Ubicacion { get; }

        public IPedidoRepositorio Pedido { get; }

        public ICategoriaRepositorio Categoria { get; }

        public IPlatilloRepositorio Platillo {  get; }

        public IPersonaRepositorio Persona { get; }
    }
}