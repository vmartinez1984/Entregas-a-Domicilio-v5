namespace EntregaADomicilio.Pedidos.Maui.Paginas;

public partial class PaginaDePlatillo : ContentPage
{
	public PaginaDePlatillo()
	{
		InitializeComponent();
	}

    private void ButtonCarrito_Clicked(object sender, EventArgs e)
    {
		var shell = Shell.Current.Items.FirstOrDefault(x => x.Route == "carrito");
		if (shell != null) {
			shell.IsVisible = true;
		}


    }
}