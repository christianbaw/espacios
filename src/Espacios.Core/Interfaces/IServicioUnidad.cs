using Espacios.Core.Binding.Unidades;
using Espacios.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IServicioUnidad
    {
        Task<UnidadVM> AgregarAsync(AgregarUnidad unidad);

        Task EliminarAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(int id, ModificarUnidad unidad);

        Task<UnidadVM> ObtenerAsync(int id);

        Task<List<UnidadVM>> ObtenerTodosAsync();
    }
}