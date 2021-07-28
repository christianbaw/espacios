using AutoMapper;
using Espacios.Core.Entidades;
using Espacios.Core.Interfaces;
using Espacios.Core.Mapeos;
using Moq;

namespace TestsUnitarios.Servicios.TestsServicioUnidad
{
    public class Base
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IRepositorioBase<Unidad>> _mockRepositorio;

        public Base()
        {
            _mockRepositorio = new Mock<IRepositorioBase<Unidad>>();

            var mapeos = new MapeoUnidad();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapeos));
            _mapper = new Mapper(configuration);
        }
    }
}