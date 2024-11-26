using EntregaADomicilio.Core.Interfaces.Repositorios;
using EntregaADomicilio.Repositorios.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace EntregaADomicilio.Repositorios.Ayudantes
{
    public static class RepositorioExtensor
    {
        public static void AgregarRepositorio(this IServiceCollection services)
        {
            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<ICategoria,CategoriaRepositorio>();
        }
    }
}