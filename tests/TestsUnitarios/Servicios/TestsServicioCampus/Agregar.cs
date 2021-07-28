using AutoMapper;
using Espacios.Core.Binding.Campus;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.Mapeos;
using Espacios.Core.Servicios;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioCampus
{
    public class Agregar : Base
    {
        private readonly Mock<IServicioUnidad> _mockServicioUnidad;

        public Agregar()
        {
            _mockServicioUnidad = new Mock<IServicioUnidad>();
        }

        [Fact]
        public async Task DebeArrojarArgumentNullException()
        {
            var servicio = new ServicioCampus(null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await servicio.AgregarAsync(null));
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockServicioUnidad.Setup(x => x.ExisteAsync(It.IsAny<int>())).ReturnsAsync(false);

            var servicio = new ServicioCampus(null, null, _mockServicioUnidad.Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.AgregarAsync(new AgregarCampus()));
        }

        [Fact]
        public async Task DebeRegresarNuevaCampus()
        {
            var id = 1;
            var nombre = "Centro";
            var unidadId = 1;
            var mapeosCampus = new MapeoCampus();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapeosCampus));
            var mapper = new Mapper(configuration);

            _mockRepositorio.Setup(x => x.AgregarAsync(It.IsAny<Campus>())).ReturnsAsync(new Campus
            {
                Id = id,
                Nombre = nombre,
                UnidadId = unidadId
            });

            _mockServicioUnidad.Setup(x => x.ExisteAsync(unidadId)).ReturnsAsync(true);

            var servicio = new ServicioCampus(mapper, _mockRepositorio.Object, _mockServicioUnidad.Object);

            var campus = await servicio.AgregarAsync(new AgregarCampus
            {
                Nombre = nombre,
                UnidadId = unidadId
            });

            Assert.NotNull(campus);
            Assert.Equal(id, campus.Id);
            Assert.Equal(nombre, campus.Nombre);
            Assert.Equal(unidadId, campus.UnidadId);
        }
    }
}