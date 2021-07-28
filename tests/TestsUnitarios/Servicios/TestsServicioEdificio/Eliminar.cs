using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioEdificio
{
    public class Eliminar : Base
    {
        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Edificio)null);

            var servicio = new ServicioEdificio(null, _mockRepositorio.Object, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.EliminarAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task DebeEliminarUnidad()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync(new Edificio());

            var servicio = new ServicioEdificio(null, _mockRepositorio.Object, null);

            await servicio.EliminarAsync(It.IsAny<int>());

            _mockRepositorio.Verify(x => x.EliminarAsync(It.IsAny<Edificio>()), Times.Once);
        }
    }
}