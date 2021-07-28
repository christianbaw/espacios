using Espacios.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Espacios.Data
{
    public static class ExtensionesDI
    {
        public static IServiceCollection AgregarBaseDeDatos(this IServiceCollection services, IConfiguration configuration)
        {
            bool usarBDEnMemoria = configuration.GetValue("DbEnMemoria", false);

            if (usarBDEnMemoria)
            {
                services.AddDbContext<EspaciosDbContext>(c => c.UseInMemoryDatabase("Espacios"));
            }
            else
            {
                string connectionString = configuration.GetConnectionString("Espacios");
                services.AddDbContext<EspaciosDbContext>(config => config.UseSqlServer(connectionString, options => options.MigrationsAssembly("Espacios.Data")));
            }

            return services;
        }

        public static IServiceCollection AgregarBaseDeDatosEnMemoria(this IServiceCollection services)
        {
            ConfigurarBaseDeDatosEnMemoria(services);
            return services;
        }

        public static IServiceCollection AgregarRepositorios(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            return services;
        }

        private static void ConfigurarBaseDeDatosEnMemoria(IServiceCollection services)
        {
            services.AddDbContext<EspaciosDbContext>(c => c.UseInMemoryDatabase("Espacios"));
        }
    }
}