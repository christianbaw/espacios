using AutoMapper;
using Espacios.Core.Entidades;
using Espacios.Core.Interfaces;
using Espacios.Core.Mapeos;
using Moq;

namespace TestsUnitarios.Servicios.TestsServicioEdificio
{
    public class Base
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IRepositorioBase<Edificio>> _mockRepositorio;

        public Base()
        {
            _mockRepositorio = new Mock<IRepositorioBase<Edificio>>();

            var mapeos = new MapeoEdificio();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapeos));
            _mapper = new Mapper(configuration);
        }
    }
}