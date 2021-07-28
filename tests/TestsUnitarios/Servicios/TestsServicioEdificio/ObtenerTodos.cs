using Espacios.Core.Entidades;
using Espacios.Core.Servicios;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioEdificio
{
    public class ObtenerTodos : Base
    {
        [Fact]
        public async Task DebeObtenerListaVacia()
        {
            _mockRepositorio.Setup(x => x.ObtenerTodosAsync()).ReturnsAsync(new List<Edificio>());

            var servicio = new ServicioEdificio(_mapper, _mockRepositorio.Object, null);

            var edificio = await servicio.ObtenerTodosAsync();

            Assert.NotNull(edificio);
            Assert.Empty(edificio);
        }

        [Fact]
        public async Task DebeObtenerTodos()
        {
            var listaEdificio = new List<Edificio>
            {
                new Edificio { Id = 1, Nombre = "Norte", CampusId = 2 },
                new Edificio { Id = 2, Nombre = "Sur", CampusId = 2 }
            };

            _mockRepositorio.Setup(x => x.ObtenerTodosAsync()).ReturnsAsync(listaEdificio);

            var servicio = new ServicioEdificio(_mapper, _mockRepositorio.Object, null);

            var edificio = await servicio.ObtenerTodosAsync();

            Assert.NotNull(edificio);
            Assert.Equal(listaEdificio.Count, edificio.Count);
        }
    }
}