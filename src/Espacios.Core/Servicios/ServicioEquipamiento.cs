using AutoMapper;
using Espacios.Core.Binding.Equipamientos;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Servicios
{
    public class ServicioEquipamiento : IServicioEquipamiento
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<Equipamiento> _repositorio;
        private readonly string _tipoEntidad = nameof(Equipamiento);

        public ServicioEquipamiento(
            IMapper mapper,
            IRepositorioBase<Equipamiento> repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<EquipamientoVM> AgregarAsync(AgregarEquipamiento equipamiento)
        {
            if (equipamiento == null)
            {
                throw new ArgumentNullException(nameof(equipamiento));
            }

            var _equipamiento = _mapper.Map<Equipamiento>(equipamiento);

            await _repositorio.AgregarAsync(_equipamiento);

            return _mapper.Map<EquipamientoVM>(_equipamiento);
        }

        public async Task EliminarAsync(int id)
        {
            var equipamiento = await _repositorio.ObtenerAsync(id);
            if (equipamiento == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await _repositorio.EliminarAsync(equipamiento);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task ModificarAsync(int id, ModificarEquipamiento equipamiento)
        {
            if (equipamiento == null)
            {
                throw new ArgumentNullException(nameof(equipamiento));
            }

            var _equipamiento = await _repositorio.ObtenerAsync(id);
            if (_equipamiento == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            _mapper.Map(equipamiento, _equipamiento);

            await _repositorio.ModificarAsync(_equipamiento);
        }

        public async Task<EquipamientoVM> ObtenerAsync(int id)
        {
            var equipamiento = await _repositorio.ObtenerAsync(id);
            if (equipamiento == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            return _mapper.Map<EquipamientoVM>(equipamiento);
        }

        public async Task<List<EquipamientoVM>> ObtenerTodosAsync()
        {
            var equipamientos = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<List<EquipamientoVM>>(equipamientos);
        }
    }
}