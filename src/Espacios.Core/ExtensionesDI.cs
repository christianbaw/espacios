using AutoMapper;
using Espacios.Core.Interfaces;
using Espacios.Core.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Espacios.Core
{
    public static class ExtensionesDI
    {
        public static IServiceCollection AgregarServicios(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IServicioUnidad, ServicioUnidad>();
            services.AddScoped<IServicioCampus, ServicioCampus>();
            services.AddScoped<IServicioEdificio, ServicioEdificio>();
            services.AddScoped<IServicioEquipamiento, ServicioEquipamiento>();
            services.AddScoped<IServicioSala, ServicioSala>();
            services.AddScoped<IServicioReservaciones, ServicioReservaciones>();
            return services;
        }
    }
}