using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioCampus
{
    public class Eliminar : Base
    {
        public Eliminar()
        {
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Campus)null);

            var servicio = new ServicioCampus(null, _mockRepositorio.Object, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.EliminarAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task DebeEliminarUnidad()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync(new Campus());

            var servicio = new ServicioCampus(null, _mockRepositorio.Object, null);

            await servicio.EliminarAsync(It.IsAny<int>());

            _mockRepositorio.Verify(x => x.EliminarAsync(It.IsAny<Campus>()), Times.Once);
        }
    }
}