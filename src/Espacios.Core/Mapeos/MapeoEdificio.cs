using AutoMapper;
using Espacios.Core.Binding.Edificios;
using Espacios.Core.Entidades;
using Espacios.Core.ViewModels;

namespace Espacios.Core.Mapeos
{
    public class MapeoEdificio : Profile
    {
        public MapeoEdificio()
        {
            CreateMap<AgregarEdificio, Edificio>();
            CreateMap<ModificarEdificio, Edificio>();
            CreateMap<Edificio, EdificioVM>();
        }
    }
}