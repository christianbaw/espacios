using Espacios.Core.Binding.Reservaciones;
using Espacios.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IServicioReservaciones
    {
        Task<ReservacionesVM> AgregarAsync(AgregarReservacion reservacion);

        Task EliminarAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(int id, ModificarReservacion reservacion);

        Task<ReservacionesVM> ObtenerAsync(int id);

        Task<List<ReservacionesVM>> ObtenerTodosAsync();
    }
}
