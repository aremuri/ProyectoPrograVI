using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;


namespace WebApplicationCore
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)//hacemos la inyeccion de dependencia de cada modulo o entidad, Metodo AddDIContainer
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClientesServices, ClientesServices>();
            services.AddTransient<IProductosService, ProductosService>();
            services.AddTransient<ICatalogoProductosService, CatalogoProductosService>();
            services.AddTransient<IPedidosService, PedidosService>();
            services.AddTransient<IEntregaServices, EntregaServices>();
            services.AddTransient<ICatalogoProvinciaService, CatalogoProvinciaService>();
            services.AddTransient<ICatalogoCantonService, CatalogoCantonService>();
            services.AddTransient<ICatalogoDistritoService, CatalogoDistritoService>();
            services.AddTransient<ICamionesServices, CamionesServices>();
            services.AddTransient<IConductorServices, ConductorServices>();
            return services;
        }
    }
}
