using EntregaADomicilio.Core.Repartidores.Dtos;
using EntregaADomicilio.Repartidor.Maui.Servicios;

namespace EntregaADomicilio.Repartidor.Maui.Paginas;

public partial class PaginaDeDetalleDelPedido : ContentPage
{
    private readonly Servicio _servicio;

    public PaginaDeDetalleDelPedido(Servicio servicio)
    {
        InitializeComponent();
        _servicio = servicio;        
    }   
    
}