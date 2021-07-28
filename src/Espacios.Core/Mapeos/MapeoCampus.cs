using AutoMapper;
using Espacios.Core.Binding.Campus;
using Espacios.Core.Entidades;
using Espacios.Core.ViewModels;

namespace Espacios.Core.Mapeos
{
    public class MapeoCampus : Profile
    {
        public MapeoCampus()
        {
            CreateMap<AgregarCampus, Campus>();
            CreateMap<ModificarCampus, Campus>();
            CreateMap<Campus, CampusVM>();
        }

    }
}
