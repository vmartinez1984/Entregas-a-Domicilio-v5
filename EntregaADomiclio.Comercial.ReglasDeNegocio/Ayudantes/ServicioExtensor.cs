using AutoMapper;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Repositorios.Ayudantes;
using EntregaADomiclio.Administracion.ReglasDeNegocio;
using EntregaADomiclio.Comercial.ReglasDeNegocio.Servicios;
using JwtTokenServicio.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntregaADomiclio.Administracion.Ayudantes
{
    public static class ServicioExtensor
    {
        public static void AgregarReglasDeNegocios(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<CategoriaRdN>();
            services.AddScoped<ClienteRdN>();
            services.AddScoped<PedidoRdN>();
            services.AddScoped<PlatilloRdN>();
            services.AddScoped<IAlmacenDeArchivos, AlmacenDeArchivoServicio>();

            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<Maper>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AgregarRepositorio();

            services.AgregarJwtAuthentication(configuration);
        }
    }
}