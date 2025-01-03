using EntregaADomicilio.Core.Repartidores.Dtos;
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

    /// <summary>
    /// Verificaci�n b�sica que no este vacio
    /// </summary>
    /// <param name="correo"></param>
    /// <param name="contrase�a"></param>
    /// <returns></returns>
    private bool SonValidosLasCredenciales(string correo, string contrase�a)
    {
        if (string.IsNullOrEmpty(correo))
        {
            LabelMensaje.Text = "El correo es obligatorio";
            return false;
        }
        if (string.IsNullOrEmpty(contrase�a))
        {
            LabelMensaje.Text = "La contrase�a es obligatoria";
            return false;
        }
        return true;
    }

    private async Task<bool> SonValidasLasCredencialesAsync(string correo, string contrasenia)
    {
        TokenDto token;

        token = await _servicio.InicioDeSesion.IniciarSesionAsync(correo, contrasenia);        
        if (token == null)
            return false;        
        else
            _servicio.Configuracion.ColocarToken(token);

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