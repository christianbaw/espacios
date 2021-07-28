using Espacios.Core.Entidades;
using Espacios.Core.Servicios;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class ObtenerTodos : Base
    {
        public ObtenerTodos()
        {
        }

        [Fact]
        public async Task DebeObtenerTodos()
        {
            var listaUnidades = new List<Unidad>
            {
                new Unidad { Id = 1, Nombre = "Navojoa" },
                new Unidad { Id = 2, Nombre = "Obregon" }
            };

            _mockRepositorio.Setup(x => x.ObtenerTodosAsync()).ReturnsAsync(listaUnidades);

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            var unidades = await servicio.ObtenerTodosAsync();

            Assert.NotNull(unidades);
            Assert.Equal(listaUnidades.Count, unidades.Count);
        }
    }
}