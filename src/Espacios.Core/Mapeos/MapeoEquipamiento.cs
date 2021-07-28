using AutoMapper;
using Espacios.Core.Binding.Equipamientos;
using Espacios.Core.Entidades;
using Espacios.Core.ViewModels;

namespace Espacios.Core.Mapeos
{
    public class MapeoEquipamiento : Profile
    {
        public MapeoEquipamiento()
        {
            CreateMap<AgregarEquipamiento, Unidad>();
            CreateMap<ModificarEquipamiento, Equipamiento>();
            CreateMap<Unidad, EquipamientoVM>();
        }
    }
}