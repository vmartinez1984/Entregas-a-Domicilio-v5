using AutoMapper;
using EntregaADomicilio.Repartidores.ReglasDeNegocio;
using EntregaADomicilio.Repositorios.Ayudantes;
using JwtTokenServicio.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntregaADomicilio.Repartidores.Ayudantes
{
    public static class ServicioExtensor
    {
        public static void AgregarRepartidores(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<RepartidorRdN>();      
            services.AddScoped<UbicacionRdN>();

            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<RepartidorMapers>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AgregarRepositorio();

            services.AgregarJwtAuthentication(configuration);
        }
    }
}
