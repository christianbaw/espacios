using Espacios.Core.Binding.Edificios;
using Espacios.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IServicioEdificio
    {
        Task<EdificioVM> AgregarAsync(AgregarEdificio Edificio);

        Task EliminarAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(int id, ModificarEdificio Edificio);

        Task<EdificioVM> ObtenerAsync(int id);

        Task<List<EdificioVM>> ObtenerTodosAsync();
    }
}