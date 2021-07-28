using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class Existe : Base
    {
        public Existe()
        {
        }

        [Fact]
        public async Task DebeEncontrarUnidad()
        {
            _mockRepositorio.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            var existe = await servicio.ExisteAsync(It.IsAny<int>());

            Assert.True(existe);
        }

        [Fact]
        public async Task NoDebeEncontrarUnidad()
        {
            _mockRepositorio.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(false);

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            var existe = await servicio.ExisteAsync(It.IsAny<int>());

            Assert.False(existe);
        }
    }
}