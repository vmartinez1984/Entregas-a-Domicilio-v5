using EntregaADomicilio.Core.Dtos.Pedidos;
using EntregaADomicilio.Pedidos.Maui.Servicios;

namespace EntregaADomicilio.Pedidos.Maui.Paginas;

public partial class PaginaDeBusqueda : ContentPage
{
    private readonly Servicio _servicio;
    private List<PlatilloDto> _platillos;
    private List<PlatilloDto> _platillosFiltrados;

    public PaginaDeBusqueda(Servicio servicio)
    {
        InitializeComponent();
        this._servicio = servicio;
        _platillosFiltrados = new List<PlatilloDto>();
        Task.Run(async () =>
        {
            _platillos = await _servicio.Platillo.ObtenerTodosAsync();
        });
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        PlatilloDto platillo;

        platillo = e.CurrentSelection.FirstOrDefault() as PlatilloDto;
        if (platillo != null)
            Navigation.PushAsync(new PaginaDePlatillo { BindingContext = platillo });
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        List<PlatilloDto> platillosFiltrados;

        var filtro = e.NewTextValue?.ToLower() ?? string.Empty;
        if (string.IsNullOrEmpty(filtro))
        {
            platillosFiltrados = _platillos;
        }
        else
        {
            // Filtrar los productos según el texto ingresado
            platillosFiltrados = _platillos
                .Where(x => x.Nombre.ToLower().Contains(filtro) || x.Descripcion.ToLower().Contains(filtro))
                .ToList();

        }
        //Actualizar las lista que se muestra
        _platillosFiltrados.Clear();
        _platillosFiltrados.AddRange(platillosFiltrados);
        this.CollectionView.ItemsSource = null;
        this.CollectionView.ItemsSource = _platillosFiltrados;
    }
}