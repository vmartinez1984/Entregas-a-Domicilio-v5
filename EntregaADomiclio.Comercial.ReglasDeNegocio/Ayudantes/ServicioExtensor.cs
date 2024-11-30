using AutoMapper;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio;
using EntregaADomicilio.Repositorios.Ayudantes;
using EntregaADomiclio.Comercial.ReglasDeNegocio.Bl;
using EntregaADomiclio.Comercial.ReglasDeNegocio.RdN;
using EntregaADomiclio.Comercial.ReglasDeNegocio.Servicios;
using JwtTokenServicio.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Ayudantes
{
    public static class ServicioExtensor
    {
        public static void AgregarReglasDeNegocios(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IReglasDeNegocio, UnitOfWork>();
            services.AddScoped<ICategoriaRdN, CategoriaRdN>();
            services.AddScoped<ICliente,ClienteRdN>();
            services.AddScoped<IPedido,PedidoRdN>();
            services.AddScoped<IPlatillo, PlatilloRdN>();              
            services.AddScoped<IAlmacenDeArchivos,AlmacenDeArchivoServicio>();

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