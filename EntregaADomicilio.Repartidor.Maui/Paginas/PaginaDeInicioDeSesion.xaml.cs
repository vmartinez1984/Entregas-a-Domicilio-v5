using EntregaADomicilio.Repartidor.Maui.Servicios;

namespace EntregaADomicilio.Repartidor.Maui.Paginas;

public partial class PaginaDeInicioDeSesion : ContentPage
{
    private readonly Servicio _servicio;

    public PaginaDeInicioDeSesion(Servicio servicio)
    {
        InitializeComponent();
        this._servicio = servicio;
    }

    private async void ButtonInicioDeSesion_Clicked(object sender, EventArgs e)
    {
        HabilitarFormulario(false);
        if (SonValidosLasCredenciales(EntryCorreo.Text, EntryContrasenia.Text))
        {
            if (await SonValidasLasCredencialesAsync(EntryCorreo.Text, EntryContrasenia.Text))
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                
            }
        }
        HabilitarFormulario(true);
    }

    private bool SonValidosLasCredenciales(string correo, string contraseña)
    {
        return true;
    }

    private async Task<bool> SonValidasLasCredencialesAsync(string correo, string contrasenia)
    {
        string token;

        token = await _servicio.InicioDeSesion.IniciarSesionAsync(correo, contrasenia);
        if (token == null)
            return false;

        return true;
    }

    private void HabilitarFormulario(bool habilitar)
    {
        EntryCorreo.IsEnabled = habilitar;
        EntryContrasenia.IsEnabled = habilitar;
        ButtonInicioDeSesion.IsEnabled = habilitar;
        ActivityIndicator.IsVisible = !habilitar;
    }
}