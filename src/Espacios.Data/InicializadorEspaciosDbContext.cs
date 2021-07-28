using Espacios.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Espacios.Data
{
    public static class InicializadorEspaciosDbContext
    {
        public static async Task InicializarBaseDeDatos(EspaciosDbContext contexto, ILogger logger, bool ejecutarSeeder = false)
        {
            await AplicarMigracionesPendientes(contexto, logger);

            if (ejecutarSeeder)
            {
                await CrearEntidades(contexto, logger);
            }
        }

        private static async Task AplicarMigracionesPendientes(EspaciosDbContext contexto, ILogger logger)
        {
            if (contexto.Database.IsSqlServer())
            {
                var pendingMigrations = await contexto.Database.GetPendingMigrationsAsync();
                logger.LogInformation($"Aplicando migraciones pendientes (total: {pendingMigrations.Count()})");
                await contexto.Database.MigrateAsync();
            }
        }

        private static async Task CrearCampus(EspaciosDbContext contexto, ILogger logger)
        {
            if (contexto.Unidad.Any() && !contexto.Campus.Any())
            {
                logger.LogInformation($"Creando Campus");

                var unidadNavojoa = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Navojoa");
                var unidadObregon = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Obregon");

                var campus = new List<Campus>
                {
                    new Campus { Nombre = "Centro", Unidad = unidadNavojoa },
                    new Campus { Nombre = "Centro", Unidad = unidadObregon }
                };

                contexto.Campus.AddRange(campus);
                await contexto.SaveChangesAsync();
            }
        }

        private static async Task CrearEdificios(EspaciosDbContext contexto, ILogger logger)
        {
            if (contexto.Campus.Any() && !contexto.Edificio.Any())
            {
                logger.LogInformation($"Creando Edificios");

                var unidadNavojoa = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Navojoa");
                var unidadObregon = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Obregon");

                var centroNavojoa = await contexto.Campus.FirstOrDefaultAsync(x => x.UnidadId == unidadNavojoa.Id && x.Nombre == "Centro");
                var centroObregon = await contexto.Campus.FirstOrDefaultAsync(x => x.UnidadId == unidadObregon.Id && x.Nombre == "Centro");

                var edificios = new List<Edificio>
                {
                    new Edificio { Nombre = "A-100", Campus = centroNavojoa },
                    new Edificio { Nombre = "A-200", Campus = centroObregon }
                };

                contexto.Edificio.AddRange(edificios);
                await contexto.SaveChangesAsync();
            }
        }

        private static async Task CrearEntidades(EspaciosDbContext contexto, ILogger logger)
        {
            await CrearEquipamiento(contexto, logger);
            await CrearUnidades(contexto, logger);
            await CrearCampus(contexto, logger);
            await CrearEdificios(contexto, logger);
            await CrearSalas(contexto, logger);
            await CrearReservaciones(contexto, logger);
        }

        private static async Task CrearEquipamiento(EspaciosDbContext contexto, ILogger logger)
        {
            if (!contexto.Equipamiento.Any())
            {
                logger.LogInformation($"Creando Equipamiento");

                var equipamientos = new List<Equipamiento>
                {
                    new Equipamiento { Nombre = "Bocina Bluetooth" },
                    new Equipamiento { Nombre = "Camara" },
                    new Equipamiento { Nombre = "Microfono" },
                    new Equipamiento { Nombre = "Proyector" }
                };

                contexto.Equipamiento.AddRange(equipamientos);
                await contexto.SaveChangesAsync();
            }
        }

        private static async Task CrearReservaciones(EspaciosDbContext contexto, ILogger logger)
        {
            if (contexto.Sala.Any() && !contexto.Reservacion.Any())
            {
                logger.LogInformation($"Creando Reservaciones");

                var unidad = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Navojoa");
                var campus = await contexto.Campus.FirstOrDefaultAsync(x => x.UnidadId == unidad.Id && x.Nombre == "Centro");
                var edificio = await contexto.Edificio.FirstOrDefaultAsync(x => x.CampusId == campus.Id && x.Nombre == "A-100");
                var sala = await contexto.Sala.FirstOrDefaultAsync(x => x.EdificioId == edificio.Id && x.Nombre == "Sala 1");

                var reservaciones = new List<Reservacion>
                {
                    new Reservacion
                    {
                        FechaInicio = DateTime.Today.AddDays(7).AddHours(13),
                        FechaFin = DateTime.Today.AddDays(7).AddHours(14),
                        Sala = sala,
                        Adicionales = "Favor de dejar asientos solo para 30 personas",
                        Estatus = EstatusEnum.Activa
                    }
                };

                contexto.Reservacion.AddRange(reservaciones);
                await contexto.SaveChangesAsync();
            }
        }

        private static async Task CrearSalas(EspaciosDbContext contexto, ILogger logger)
        {
            if (contexto.Edificio.Any() && contexto.Equipamiento.Any() && !contexto.Sala.Any())
            {
                logger.LogInformation($"Creando Salas");

                var unidadNavojoa = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Navojoa");
                var unidadObregon = await contexto.Unidad.FirstOrDefaultAsync(x => x.Nombre == "Obregon");

                var centroNavojoa = await contexto.Campus.FirstOrDefaultAsync(x => x.UnidadId == unidadNavojoa.Id && x.Nombre == "Centro");
                var centroObregon = await contexto.Campus.FirstOrDefaultAsync(x => x.UnidadId == unidadObregon.Id && x.Nombre == "Centro");

                var a100Navojoa = await contexto.Edificio.FirstOrDefaultAsync(x => x.CampusId == centroNavojoa.Id && x.Nombre == "A-100");
                var a200Obregon = await contexto.Edificio.FirstOrDefaultAsync(x => x.CampusId == centroObregon.Id && x.Nombre == "A-200");

                var equipamiento = await contexto.Equipamiento.FirstOrDefaultAsync(x => x.Nombre == "Proyector");
                var salaConEquipamiento = new Sala { Nombre = "Sala 1", Edificio = a100Navojoa };
                salaConEquipamiento.AgregarEquipamiento(equipamiento.Id);

                var salas = new List<Sala>
                {
                    salaConEquipamiento,
                    new Sala { Nombre = "Sala 1", Edificio = a200Obregon }
                };

                contexto.Sala.AddRange(salas);
                await contexto.SaveChangesAsync();
            }
        }

        private static async Task CrearUnidades(EspaciosDbContext contexto, ILogger logger)
        {
            if (!contexto.Unidad.Any())
            {
                logger.LogInformation($"Creando Unidades");

                var unidades = new List<Unidad>
                {
                    new Unidad { Nombre = "Navojoa"},
                    new Unidad { Nombre = "Obregon"}
                };

                contexto.Unidad.AddRange(unidades);
                await contexto.SaveChangesAsync();
            }
        }
    }
}