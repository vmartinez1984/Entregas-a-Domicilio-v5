using AutoMapper;
using EntregaADomicilio.Core.Interfaces.ReglasDeNegocio.Pedidos;
using EntregaADomicilio.Repositorios.Ayudantes;
using EntregaADomiclio.Comercial.ReglasDeNegocio.RdN.Pedidos;
using JwtTokenServicio.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntregaADomiclio.Comercial.ReglasDeNegocio.Ayudantes
{
    public static class ServicioPedidosExtensor
    {      
        public static void AgregarPedidos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPedidosUoW, PedidosUoW>();
            services.AddScoped<ICategoriaRdN, CategoriaRdN>();

            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<PedidosMapper>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AgregarRepositorio();

            services.AgregarJwtAuthentication(configuration);
        }
    }
}