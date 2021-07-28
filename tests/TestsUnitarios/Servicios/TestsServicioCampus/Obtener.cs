using AutoMapper;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Mapeos;
using Espacios.Core.Servicios;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioCampus
{
    public class Obtener : Base
    {
        public Obtener()
        {
        }

        [Fact]
        public async Task DebeArrojarNotFoundException()
        {
            _mockRepositorio.Setup(x => x.ObtenerAsync(It.IsAny<int>())).ReturnsAsync((Campus)null);

            var servicio = new ServicioCampus(null, _mockRepositorio.Object, null);

            await Assert.ThrowsAsync<NotFoundException>(async () => await servicio.ObtenerAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task DebeObtenerCampus()
        {
            var mapeosCampus = new MapeoCampus();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapeosCampus));
            var mapper = new Mapper(configuration);
            var id = 1;
            var nombre = "Centro";
            var unidadId = 2;

            _mockRepositorio.Setup(x => x.ObtenerAsync(id)).ReturnsAsync(new Campus { Id = id, Nombre = nombre, UnidadId = unidadId });

            var servicio = new ServicioCampus(mapper, _mockRepositorio.Object, null);
            var campus = await servicio.ObtenerAsync(id);

            Assert.Equal(id, campus.Id);
            Assert.Equal(nombre, campus.Nombre);
            Assert.Equal(unidadId, campus.UnidadId);
        }
    }
}