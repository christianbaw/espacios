using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioEdificio
{
    public class Obtener : Base
    {
        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Edificio)null);

            var servicio = new ServicioEdificio(null, _mockRepositorio.Object, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.ObtenerAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task DebeObtenerEdificio()
        {
            var id = 1;
            var nombre = "Norte";
            var campusId = 2;

            _mockRepositorio.Setup(x => x.ObtenerAsync(id)).ReturnsAsync(new Edificio
            {
                Id = id,
                Nombre = nombre,
                CampusId = campusId
            });

            var servicio = new ServicioEdificio(_mapper, _mockRepositorio.Object, null);
            var edificio = await servicio.ObtenerAsync(id);

            Assert.Equal(id, edificio.Id);
            Assert.Equal(nombre, edificio.Nombre);
            Assert.Equal(campusId, edificio.CampusId);
        }
    }
}