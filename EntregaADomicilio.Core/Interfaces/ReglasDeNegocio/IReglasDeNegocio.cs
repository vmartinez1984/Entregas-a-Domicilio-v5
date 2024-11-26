namespace EntregaADomicilio.Core.Interfaces.ReglasDeNegocio
{
    public interface IReglasDeNegocio
    {
        ICategoriaRdN Categoria { get; }

        IPlatillo Platillo { get; }

        ICliente Cliente { get; }

        IPedido Pedido { get; }
    }
}
