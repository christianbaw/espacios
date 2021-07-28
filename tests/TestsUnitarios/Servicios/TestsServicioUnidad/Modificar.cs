using Espacios.Core.Binding.Unidades;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Servicios;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class Modificar : Base
    {
        public Modificar()
        {
        }

        [Fact]
        public async Task DebeArrojarArgumentNullException()
        {
            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await servicio.ModificarAsync(0, null));
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Unidad)null);

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.ModificarAsync(It.IsAny<int>(), new ModificarUnidad()));
        }

        [Fact]
        public async Task DebeModificarUnidad()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync(new Unidad());

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            await servicio.ModificarAsync(1, new ModificarUnidad());

            _mockRepositorio.Verify(x => x.ModificarAsync(It.IsAny<Unidad>()), Times.Once);
        }
    }
}