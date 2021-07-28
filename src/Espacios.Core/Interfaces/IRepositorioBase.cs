using Espacios.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Interfaces
{
    public interface IRepositorioBase<T> where T : EntidadBase
    {
        Task<T> AgregarAsync(T entity);

        Task EliminarAsync(T entity);

        Task<bool> ExisteAsync(int id);

        Task ModificarAsync(T entity);

        Task<T> ObtenerAsync(int id);

        Task<IList<T>> ObtenerTodosAsync();
    }
}