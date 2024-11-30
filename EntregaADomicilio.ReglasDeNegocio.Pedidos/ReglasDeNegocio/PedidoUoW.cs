namespace EntregaADomicilio.Pedidos.ReglasDeNegocio;

public class PedidoUoW
{
    public CategoriaRdN Categoria { get; }

    public PlatilloRdN Platillo { get; }

    public ClienteRdN Cliente { get;  }

    public PedidoRdN Pedido { get;  }

    public PedidoUoW(
        PlatilloRdN platilloRdN,
        CategoriaRdN categoriaRdN,
        ClienteRdN clienteRdN,
        PedidoRdN pedidoRdN
    )
    {
        Categoria = categoriaRdN;
        Platillo = platilloRdN;
        Cliente = clienteRdN;
        Pedido = pedidoRdN;
    }
}
