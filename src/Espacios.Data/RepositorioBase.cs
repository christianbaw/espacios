using Espacios.Core.Entidades;
using Espacios.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Data
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadBase
    {
        private readonly EspaciosDbContext _contexto;

        public RepositorioBase(EspaciosDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<T> AgregarAsync(T entity)
        {
            await _contexto.Set<T>().AddAsync(entity);
            await _contexto.SaveChangesAsync();
            return entity;
        }

        public async Task EliminarAsync(T entity)
        {
            _contexto.Set<T>().Remove(entity);
            await _contexto.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _contexto.Set<T>().AnyAsync(x => x.Id == id);
        }

        public async Task ModificarAsync(T entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task<T> ObtenerAsync(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> ObtenerTodosAsync()
        {
            return await _contexto.Set<T>().ToListAsync();
        }
    }
}