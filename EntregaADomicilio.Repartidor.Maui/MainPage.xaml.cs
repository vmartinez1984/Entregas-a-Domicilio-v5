using EntregaADomicilio.Repartidor.Maui.Servicios;

namespace EntregaADomicilio.Repartidor.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly Servicio _servicio;
        int count = 0;

        public MainPage(Servicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        /// <summary>
        /// Cuando está a punto de aparecer la pantala
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Iniciar la animación del ActivityIndicator
            this.ActivityIndicator.IsVisible = true;
            ListView.ItemsSource = await _servicio.Pedido.ObtenerTodosAsync();
            // Detener la animación del ActivityIndicator        
            this.ActivityIndicator.IsVisible = false;
        }

    }

}
