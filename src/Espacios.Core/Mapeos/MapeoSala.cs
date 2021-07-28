using AutoMapper;
using Espacios.Core.Binding.Salas;
using Espacios.Core.Entidades;
using Espacios.Core.ViewModels;

namespace Espacios.Core.Mapeos
{
    public class MapeoSala : Profile
    {
        public MapeoSala()
        {
            CreateMap<AgregarSala, Sala>();
            CreateMap<ModificarSala, Sala>();
            CreateMap<Sala, SalaVM>();
        }
    }
}