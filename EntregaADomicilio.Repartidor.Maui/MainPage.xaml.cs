using EntregaADomicilio.Core.Repartidores.Dtos;
using EntregaADomicilio.Repartidor.Maui.Paginas;
using EntregaADomicilio.Repartidor.Maui.Servicios;

namespace EntregaADomicilio.Repartidor.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly Servicio _servicio;

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

        /// <summary>
        /// Mostar en otra page los detalles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new PaginaDeDetalleDelPedido(_servicio) { BindingContext = e.Item as PedidoDto});
        }
    }
}