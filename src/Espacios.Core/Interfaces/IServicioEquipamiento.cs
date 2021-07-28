using Espacios.Core.Binding.Equipamientos;
using Espacios.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IServicioEquipamiento
    {
        Task<EquipamientoVM> AgregarAsync(AgregarEquipamiento equipamiento);

        Task EliminarAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(int id, ModificarEquipamiento equipamiento);

        Task<EquipamientoVM> ObtenerAsync(int id);

        Task<List<EquipamientoVM>> ObtenerTodosAsync();
    }
}