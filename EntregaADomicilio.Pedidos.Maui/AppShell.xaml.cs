namespace EntregaADomicilio.Pedidos.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public void MostarTabDeCarrito()
        {
            TabCarrito.IsVisible = true;
        }

        public void OcultarTabDeCarrito()
        {
            TabCarrito.IsVisible = false;
        }
    }
}
