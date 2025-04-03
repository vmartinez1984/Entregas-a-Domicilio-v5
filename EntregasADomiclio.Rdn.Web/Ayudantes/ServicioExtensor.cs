using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Repositorios.Ayudantes;
using EntregasADomicilio.StoreFiles;
using EntregasADomicilio.Web.ReglasDeNegocio;
using Microsoft.Extensions.DependencyInjection;

namespace EntregasADomicilio.Web.Ayudantes
{
    public static class ServicioExtensor
    {
        public static void AgregarReglasDeNegocios(this IServiceCollection services
        //, IConfiguration configuration
        )
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<CategoriaRdn>();
            services.AddScoped<ProductosRdn>();
            services.AddScoped<IAlmacenDeArchivos, AlmacenDeArchivosFirebase>();

            services.AgregarRepositorio();

            //services.AgregarJwtAuthentication(configuration);
        }
    }
}