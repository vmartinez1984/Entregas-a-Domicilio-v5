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
        }
        ListView.ItemsSource = categorias;
        //ConstruirElGrid(await _servicio.Categoria.ObtenerTodosAsync());
        // Detener la animación del ActivityIndicator        
        this.ActivityIndicator.IsVisible = false;
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        CategoriaDto categoria;

        categoria = (CategoriaDto)e.Item;
        Navigation.PushAsync(new PaginaDeCategoria(_servicio) { BindingContext = categoria }, true);
    }

    //private void ConstruirElGrid(List<CategoriaDto> categorias)
    //{
    //    this.Grid = new Grid
    //    {
    //        Padding = 10,
    //        ColumnDefinitions =
    //        {
    //            new ColumnDefinition{Width = GridLength.Auto},
    //            new ColumnDefinition{Width = GridLength.Auto}
    //        }
    //    };

    //    for (int i = 0; i < categorias.Count; i++)
    //    {
    //        this.Grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
    //    }

    //    for (int i = 0; i < categorias.Count; i = i + 2)
    //    {
    //        var categoria = categorias[i];
    //        this.Grid.Add(new Label { Text = categoria.Nombre }, 0, i);
    //        this.Grid.Add(new Label { Text = categoria.Nombre }, 1, i);
    //    }
    //}
}