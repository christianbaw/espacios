using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioCampus
{
    public class Existe : Base
    {
        public Existe()
        {
        }

        [Fact]
        public async Task DebeEncontrarCampus()
        {
            _mockRepositorio.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var servicio = new ServicioCampus(null, _mockRepositorio.Object, null);

            var existe = await servicio.ExisteAsync(It.IsAny<int>());

            Assert.True(existe);
        }

        [Fact]
        public async Task NoDebeEncontrarCampus()
        {
            _mockRepositorio.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(false);

            var servicio = new ServicioCampus(null, _mockRepositorio.Object, null);

            var existe = await servicio.ExisteAsync(It.IsAny<int>());

            Assert.False(existe);
        }
    }
}