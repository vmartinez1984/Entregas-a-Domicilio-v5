using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Pedidos.Maui.Servicios;

namespace EntregaADomicilio.Pedidos.Maui.Paginas;

public partial class PaginaDeCategoria : ContentPage
{
    private readonly Servicio _servicio;

    public PaginaDeCategoria(Servicio servicio)
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
        CategoriaDto categoria;
        List<PlatilloDto> platillos;

        categoria = (CategoriaDto)BindingContext;
        platillos = (List<PlatilloDto>)await _servicio.Platillo.ObtenerPorCategoriaIdAsync(categoria.Id);
        platillos.ForEach(item =>
        {
            item.EnlaceDeImagen = _servicio.Configuracion.ObtenerUrl(item.EnlaceDeImagen);
            item.EnlaceDeImagen = "https://file.adomicil.io/luckysushi.tr3sco.net/_files/images/product/kushiagues-platano-0550904447003689-0270853443663033.png";
        });
        this.CollectionView.ItemsSource = platillos;
        // Detener la animación del ActivityIndicator        
        this.ActivityIndicator.IsVisible = false;
    }


    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        PlatilloDto platilloDto;

        platilloDto = (PlatilloDto)e.Item;
        Navigation.PushAsync(new PaginaDePlatillo { BindingContext = platilloDto });

    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        PlatilloDto platillo;

        platillo = e.CurrentSelection.FirstOrDefault() as PlatilloDto;
        if (platillo != null)
            Navigation.PushAsync(new PaginaDePlatillo { BindingContext = platillo });
    }
}