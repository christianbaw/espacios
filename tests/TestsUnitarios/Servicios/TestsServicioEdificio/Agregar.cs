using Espacios.Core.Binding.Edificios;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.Servicios;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioEdificio
{
    public class Agregar : Base
    {
        private readonly Mock<IServicioCampus> _mockServicioCampus;

        public Agregar()
        {
            _mockServicioCampus = new Mock<IServicioCampus>();
        }

        [Fact]
        public async Task DebeArrojarArgumentNullException()
        {
            var servicio = new ServicioEdificio(null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await servicio.AgregarAsync(null));
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockServicioCampus.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(false);

            var servicio = new ServicioEdificio(null, null, _mockServicioCampus.Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.AgregarAsync(new AgregarEdificio()));
        }

        [Fact]
        public async Task DebeRegresarNuevoEdificio()
        {
            var id = 1;
            var nombre = "Norte";
            var campusId = 1;

            _mockRepositorio.Setup(x => x.AgregarAsync(It.IsAny<Edificio>())).ReturnsAsync(new Edificio
            {
                Id = id,
                Nombre = nombre,
                CampusId = campusId
            });

            _mockServicioCampus.Setup(x => x.ExisteAsync(campusId)).ReturnsAsync(true);

            var servicio = new ServicioEdificio(_mapper, _mockRepositorio.Object, _mockServicioCampus.Object);

            var edificio = await servicio.AgregarAsync(new AgregarEdificio
            {
                Nombre = nombre,
                CampusId = campusId
            });

            Assert.NotNull(edificio);
            Assert.Equal(id, edificio.Id);
            Assert.Equal(nombre, edificio.Nombre);
            Assert.Equal(campusId, edificio.CampusId);
        }
    }
}