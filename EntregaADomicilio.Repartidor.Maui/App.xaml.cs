using EntregaADomicilio.Repartidor.Maui.Paginas;
using EntregaADomicilio.Repartidor.Maui.Servicios;

namespace EntregaADomicilio.Repartidor.Maui
{
    public partial class App : Application
    {
        public App(Servicio servicio)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PaginaDeInicioDeSesion(servicio));
        }
    }
}
