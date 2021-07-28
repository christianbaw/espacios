using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class Obtener : Base
    {
        public Obtener()
        {
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Unidad)null);

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.ObtenerAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task DebeObtenerUnidad()
        {
            var id = 1;
            var nombre = "Hermosillo";

            _mockRepositorio.Setup(x => x.ObtenerAsync(id)).ReturnsAsync(new Unidad { Id = id, Nombre = nombre });

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);
            var unidad = await servicio.ObtenerAsync(id);

            Assert.Equal(id, unidad.Id);
            Assert.Equal(nombre, unidad.Nombre);
        }
    }
}