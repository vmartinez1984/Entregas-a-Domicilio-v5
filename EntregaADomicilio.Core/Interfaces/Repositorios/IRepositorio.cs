namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IRepositorio
    {
        ICategoriaRepositorio Categoria { get; }

        IPlatilloRepositorio Platillo { get; }

        IPersonaRepositorio Persona { get; }

        IPedidoRepositorio Pedido { get; }
        
        IUbicacionRepositorio Ubicacion { get; }
    }
}