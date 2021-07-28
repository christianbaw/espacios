using AutoMapper;
using Espacios.Core.Binding.Unidades;
using Espacios.Core.Entidades;
using Espacios.Core.ViewModels;

namespace Espacios.Core.Mapeos
{
    public class MapeoUnidad : Profile
    {
        public MapeoUnidad()
        {
            CreateMap<AgregarUnidad, Unidad>();
            CreateMap<ModificarUnidad, Unidad>();
            CreateMap<Unidad, UnidadVM>();
        }
    }
}