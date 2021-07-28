using Espacios.Core.Entidades;
using Espacios.Core.Interfaces;
using Espacios.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace TestsIntegracion.Repositories.RepositorioUnidad
{
    public class Agregar
    {
        private readonly EspaciosDbContext _contexto;
        private readonly IRepositorioBase<Unidad> _repositorio;

        public Agregar()
        {
            var dbOptions = new DbContextOptionsBuilder<EspaciosDbContext>()
                .UseInMemoryDatabase(databaseName: "Espacios")
                .Options;

            _contexto = new EspaciosDbContext(dbOptions);
            _repositorio = new RepositorioBase<Unidad>(_contexto);
        }

        [Fact]
        public async Task AgregarEntidad()
        {
            var unidad = new Unidad
            {
                Nombre = null
            };

            var entidad = await _repositorio.AgregarAsync(unidad);

            Assert.NotNull(entidad);
            Assert.True(entidad.Id > 0);
            Assert.Equal(entidad.Nombre, unidad.Nombre);
        }
    }
}