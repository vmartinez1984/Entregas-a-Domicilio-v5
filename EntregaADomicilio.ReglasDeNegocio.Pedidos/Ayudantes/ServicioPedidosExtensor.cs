﻿using AutoMapper;
using EntregaADomicilio.Core.Interfaces.Almacenes;
using EntregaADomicilio.Pedidos.ReglasDeNegocio;
using EntregaADomicilio.Repositorios.Ayudantes;
using EntregasADomicilio.StoreFiles;
using JwtTokenServicio.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntregaADomicilio.Pedidos.Ayudantes
{
    public static class ServicioPedidosExtensor
    {      
        public static void AgregarPedidos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PedidoUoW>();
            services.AddScoped<CategoriaRdN>();
            services.AddScoped<ClienteRdN>();
            services.AddScoped<PlatilloRdN>();
            services.AddScoped<PedidoRdN>();
            services.AddScoped<IAlmacenDeArchivos, AlmacenDeArchivosFirebase>();

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