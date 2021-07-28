using Espacios.Core.Binding.Unidades;
using Espacios.Core.Entidades;
using Espacios.Core.Servicios;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class Agregar : Base
    {
        public Agregar()
        {
        }

        [Fact]
        public async Task DebeArrojarArgumentNullException()
        {
            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await servicio.AgregarAsync(null));
        }

        [Fact]
        public async Task DebeRegresarNuevaUnidad()
        {
            var id = 1;
            var nombre = "Hermosillo";

            _mockRepositorio.Setup(x => x.AgregarAsync(It.IsAny<Unidad>())).ReturnsAsync(new Unidad
            {
                Id = id,
                Nombre = nombre
            });

            var servicio = new ServicioUnidad(_mapper, _mockRepositorio.Object);
            var unidad = await servicio.AgregarAsync(new AgregarUnidad
            {
                Nombre = nombre
            });

            Assert.NotNull(unidad);
            Assert.Equal(id, unidad.Id);
            Assert.Equal(nombre, unidad.Nombre);
        }
    }
}