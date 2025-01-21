namespace EntregaADomicilio.Pedidos.Maui.Paginas;

public partial class PaginaDePlatillo : ContentPage
{
    public PaginaDePlatillo()
    {
        InitializeComponent();
        // Obtener el ancho de la pantalla en píxeles
        var anchoPantalla = DeviceDisplay.MainDisplayInfo.Width;

        // Convertir a unidades de dispositivo (DP)
        var anchoPantallaEnDP = anchoPantalla / DeviceDisplay.MainDisplayInfo.Density;

        Image.WidthRequest = anchoPantallaEnDP;
    }

    private void ButtonCarrito_Clicked(object sender, EventArgs e)
    {
        // Accede a AppShell y actualiza la visibilidad del carrito
        if (Application.Current.MainPage is AppShell appShell)
        {
            appShell.MostarTabDeCarrito();
            Navigation.PopAsync();
        }
    }
}