using EntregaADomicilio.Pedidos.Maui.Paginas;
using EntregaADomicilio.Pedidos.Maui.Servicios;
using Microsoft.Extensions.Logging;

namespace EntregaADomicilio.Pedidos.Maui
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
            builder.Services.AddSingleton<ServicioDeCategoria>();
            builder.Services.AddSingleton<ServicioDeConfiguracion>();
            builder.Services.AddSingleton<ServicioDePlatillo>();


            builder.Services.AddSingleton<PaginaDeMenu>();
            builder.Services.AddSingleton<PaginaDeBusqueda>();
            builder.Services.AddSingleton<PaginaDeCategoria>();
            builder.Services.AddSingleton<PaginaDePerfil>();
            builder.Services.AddSingleton<PaginaDePlatillo>();


            return builder.Build();
        }
    }
}
