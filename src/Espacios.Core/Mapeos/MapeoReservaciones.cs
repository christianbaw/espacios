using AutoMapper;
using Espacios.Core.Binding.Reservaciones;
using Espacios.Core.Entidades;
using Espacios.Core.ViewModels;

namespace Espacios.Core.Mapeos
{
    public class MapeoReservaciones : Profile
    {
        public MapeoReservaciones()
        {
            CreateMap<AgregarReservacion, Reservacion>();
            CreateMap<ModificarReservacion, Reservacion>();
            CreateMap<Reservacion, ReservacionesVM>();
        }
    }
}
