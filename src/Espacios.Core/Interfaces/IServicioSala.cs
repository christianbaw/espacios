using Espacios.Core.Binding.Salas;
using Espacios.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IServicioSala
    {
        Task<SalaVM> AgregarAsync(AgregarSala sala);

        Task EliminarAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(int id, ModificarSala sala);

        Task<SalaVM> ObtenerAsync(int id);

        Task<List<SalaVM>> ObtenerTodosAsync();
    }
}