using Espacios.Core.Binding.Campus;
using Espacios.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IServicioCampus
    {
        Task<CampusVM> AgregarAsync(AgregarCampus campus);

        Task EliminarAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(int id, ModificarCampus campus);

        Task<CampusVM> ObtenerAsync(int id);

        Task<List<CampusVM>> ObtenerTodosAsync();
    }
}