using Espacios.Core.Entidades;
using Espacios.Core.Servicios;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioCampus
{
    public class ObtenerTodos : Base
    {
        public ObtenerTodos()
        {
        }

        [Fact]
        public async Task DebeObtenerListaVacia()
        {
            _mockRepositorio.Setup(x => x.ObtenerTodosAsync()).ReturnsAsync(new List<Campus>());

            var servicio = new ServicioCampus(_mapper, _mockRepositorio.Object, null);

            var campus = await servicio.ObtenerTodosAsync();

            Assert.NotNull(campus);
            Assert.Empty(campus);
        }

        [Fact]
        public async Task DebeObtenerTodos()
        {
            var listaCampus = new List<Campus>
            {
                new Campus { Id = 1, Nombre = "Centro", UnidadId = 2 },
                new Campus { Id = 2, Nombre = "Sur", UnidadId = 2 }
            };

            _mockRepositorio.Setup(x => x.ObtenerTodosAsync()).ReturnsAsync(listaCampus);

            var servicio = new ServicioCampus(_mapper, _mockRepositorio.Object, null);

            var campus = await servicio.ObtenerTodosAsync();

            Assert.NotNull(campus);
            Assert.Equal(listaCampus.Count, campus.Count);
        }
    }
}