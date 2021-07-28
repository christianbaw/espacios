using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioEdificio
{
    public class Existe : Base
    {
        [Fact]
        public async Task DebeEncontrarEdificio()
        {
            _mockRepositorio.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var servicio = new ServicioEdificio(null, _mockRepositorio.Object, null);

            var existe = await servicio.ExisteAsync(It.IsAny<int>());

            Assert.True(existe);
        }

        [Fact]
        public async Task NoDebeEncontrarEdificio()
        {
            _mockRepositorio.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(false);

            var servicio = new ServicioEdificio(null, _mockRepositorio.Object, null);

            var existe = await servicio.ExisteAsync(It.IsAny<int>());

            Assert.False(existe);
        }
    }
}