using AutoMapper;
using Espacios.Core.Binding.Campus;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Servicios
{
    public class ServicioCampus : IServicioCampus
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<Campus> _repositorio;
        private readonly IServicioUnidad _servicioUnidad;

        public ServicioCampus(
            IMapper mapper,
            IRepositorioBase<Campus> repositorio,
            IServicioUnidad servicioUnidad)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _servicioUnidad = servicioUnidad;
        }

        public async Task<CampusVM> AgregarAsync(AgregarCampus campus)
        {
            if (campus == null)
            {
                throw new ArgumentNullException(nameof(campus));
            }

            if (!await _servicioUnidad.ExisteAsync(campus.UnidadId))
            {
                throw new NotFoundException(nameof(Unidad), campus.UnidadId);
            }

            var _campus = await _repositorio.AgregarAsync(_mapper.Map<Campus>(campus));

            return _mapper.Map<CampusVM>(_campus);
        }

        public async Task EliminarAsync(int id)
        {
            var campus = await _repositorio.ObtenerAsync(id);
            if (campus == null)
            {
                throw new NotFoundException(id);
            }

            await _repositorio.EliminarAsync(campus);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task ModificarAsync(int id, ModificarCampus campus)
        {
            if (campus == null)
            {
                throw new ArgumentNullException(nameof(Campus));
            }

            if (!await _servicioUnidad.ExisteAsync(campus.UnidadId))
            {
                throw new NotFoundException(nameof(Unidad), campus.UnidadId);
            }

            var _campus = await _repositorio.ObtenerAsync(id);
            if (_campus == null)
            {
                throw new NotFoundException(id);
            }

            _mapper.Map(campus, _campus);

            await _repositorio.ModificarAsync(_campus);
        }

        public async Task<CampusVM> ObtenerAsync(int id)
        {
            var campus = await _repositorio.ObtenerAsync(id);
            if (campus == null)
            {
                throw new NotFoundException(id);
            }

            return _mapper.Map<CampusVM>(campus);
        }

        public async Task<List<CampusVM>> ObtenerTodosAsync()
        {
            var campus = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<List<CampusVM>>(campus);
        }
    }
}