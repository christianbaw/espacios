using AutoMapper;
using Espacios.Core.Entidades;
using Espacios.Core.Interfaces;
using Espacios.Core.Mapeos;
using Moq;

namespace TestsUnitarios.Servicios.TestsServicioCampus
{
    public class Base
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IRepositorioBase<Campus>> _mockRepositorio;

        public Base()
        {
            _mockRepositorio = new Mock<IRepositorioBase<Campus>>();

            var mapeos = new MapeoCampus();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapeos));
            _mapper = new Mapper(configuration);
        }
    }
}