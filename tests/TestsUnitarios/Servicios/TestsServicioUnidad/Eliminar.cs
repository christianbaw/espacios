using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class Eliminar : Base
    {
        public Eliminar()
        {
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Unidad)null);

            var servicio = new ServicioUnidad(null, _mockRepositorio.Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.EliminarAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task DebeEliminarUnidad()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync(new Unidad { Id = 1, Nombre = "Hermosillo" });

            var servicio = new ServicioUnidad(null, _mockRepositorio.Object);

            await servicio.EliminarAsync(It.IsAny<int>());

            _mockRepositorio.Verify(x => x.EliminarAsync(It.IsAny<Unidad>()), Times.Once);
        }
    }
}