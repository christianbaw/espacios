using AutoMapper;
using Espacios.Core.Binding.Unidades;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Servicios
{
    public class ServicioUnidad : IServicioUnidad
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<Unidad> _repositorio;
        private readonly string _tipoEntidad = nameof(Unidad);

        public ServicioUnidad(
            IMapper mapper,
            IRepositorioBase<Unidad> repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<UnidadVM> AgregarAsync(AgregarUnidad unidad)
        {
            if (unidad == null)
            {
                throw new ArgumentNullException(nameof(unidad));
            }

            var _unidad = await _repositorio.AgregarAsync(_mapper.Map<Unidad>(unidad));
            return _mapper.Map<UnidadVM>(_unidad);
        }

        public async Task EliminarAsync(int id)
        {
            var unidad = await _repositorio.ObtenerAsync(id);
            if (unidad == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await _repositorio.EliminarAsync(unidad);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task ModificarAsync(int id, ModificarUnidad unidad)
        {
            if (unidad == null)
            {
                throw new ArgumentNullException(nameof(Unidad));
            }

            var _unidad = await _repositorio.ObtenerAsync(id);
            if (_unidad == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            var entidad = _mapper.Map(unidad, _unidad);
            await _repositorio.ModificarAsync(entidad);
        }

        public async Task<UnidadVM> ObtenerAsync(int id)
        {
            var unidad = await _repositorio.ObtenerAsync(id);
            if (unidad == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            return _mapper.Map<UnidadVM>(unidad);
        }

        public async Task<List<UnidadVM>> ObtenerTodosAsync()
        {
            var unidades = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<List<UnidadVM>>(unidades);
        }
    }
}