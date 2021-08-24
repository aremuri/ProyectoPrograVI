using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;


namespace WebApiRest
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)//hacemos la inyeccion de dependencia de cada modulo o entidad, Metodo AddDIContainer
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClientesServices, ClientesServices>();
            services.AddTransient<IProductosService, ProductosService>();
            services.AddTransient<ICatalogoProductosService, CatalogoProductosService>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            return services;
        }
    }
}
