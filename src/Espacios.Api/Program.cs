using Espacios.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Espacios.Api
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await PrepararBaseDeDatos(host);
            host.Run();
        }

        private static async Task PrepararBaseDeDatos(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            var configuration = services.GetRequiredService<IConfiguration>();
            var logger = loggerFactory.CreateLogger<Program>();

            try
            {
                var context = services.GetRequiredService<EspaciosDbContext>();
                var ejecutarSeeder = configuration.GetValue("EjecutarSeeder", false);
                await InicializadorEspaciosDbContext.InicializarBaseDeDatos(context, logger, ejecutarSeeder);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrio un error al preparar la base de datos");
            }
        }
    }
}