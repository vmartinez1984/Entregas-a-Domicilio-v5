namespace EntregaADomicilio.Core.Interfaces.Repositorios
{
    public interface IRepositorio
    {
        ICategoriaRepositorio Categoria { get; }

        IPlatilloRepositorio Platillo { get; }
    }
}