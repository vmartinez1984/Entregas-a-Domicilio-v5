using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Pedidos.Maui.Servicios;

namespace EntregaADomicilio.Pedidos.Maui.Paginas;

public partial class PaginaDeMenu : ContentPage
{
    private readonly Servicio _servicio;

    public PaginaDeMenu(Servicio servicio)
    {
        InitializeComponent();
        this._servicio = servicio;
    }

    /// <summary>
    /// Cuando está a punto de aparecer la pantala
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Iniciar la animación del ActivityIndicator
        this.ActivityIndicator.IsVisible = true;
        List<CategoriaDto> categorias;

        categorias = await _servicio.Categoria.ObtenerTodosAsync();
        foreach (var item in categorias)
        {
            item.Url = _servicio.Configuracion.ObtenerUrl($"Categorias/{item.Id}/Imagen");
            item.Url = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/entrada-edamame-vapor-010119-0492943390036441-0464231620293218.png";
        }        
        CollectionView.ItemsSource = categorias;        
        // Detener la animación del ActivityIndicator        
        this.ActivityIndicator.IsVisible = false;
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        CategoriaDto categoria;

        categoria = e.CurrentSelection.FirstOrDefault() as CategoriaDto;
        if (categoria != null)
            Navigation.PushAsync(new PaginaDeCategoria(_servicio) { BindingContext = categoria }, true);
    }   
}