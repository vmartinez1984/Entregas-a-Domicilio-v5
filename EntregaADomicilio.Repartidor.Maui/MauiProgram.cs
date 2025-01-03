using EntregaADomicilio.Repartidor.Maui.Paginas;
using EntregaADomicilio.Repartidor.Maui.Servicios;
using Microsoft.Extensions.Logging;

namespace EntregaADomicilio.Repartidor.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddHttpClient("").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            builder.Services.AddSingleton<Servicio>();
            builder.Services.AddSingleton<ServicioDeConfiguracion>();
            builder.Services.AddSingleton<ServicioDeInicioDeSesion>();

            builder.Services.AddSingleton<PaginaDeInicioDeSesion>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
