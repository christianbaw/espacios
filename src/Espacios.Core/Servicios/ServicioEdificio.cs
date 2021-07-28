using AutoMapper;
using Espacios.Core.Binding.Edificios;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Servicios
{
    public class ServicioEdificio : IServicioEdificio
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<Edificio> _repositorio;
        private readonly IServicioCampus _servicioCampus;
        private readonly string _tipoEntidad = nameof(Edificio);

        public ServicioEdificio(
            IMapper mapper,
            IRepositorioBase<Edificio> repositorio,
            IServicioCampus servicioCampus)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _servicioCampus = servicioCampus;
        }

        public async Task<EdificioVM> AgregarAsync(AgregarEdificio edificio)
        {
            if (edificio == null)
            {
                throw new ArgumentNullException(nameof(edificio));
            }

            if (!await _servicioCampus.ExisteAsync(edificio.CampusId))
            {
                throw new NotFoundException(nameof(Campus), edificio.CampusId);
            }

            var _edificio = await _repositorio.AgregarAsync(_mapper.Map<Edificio>(edificio));

            return _mapper.Map<EdificioVM>(_edificio);
        }

        public async Task EliminarAsync(int id)
        {
            var edificio = await _repositorio.ObtenerAsync(id);
            if (edificio == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await _repositorio.EliminarAsync(edificio);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task ModificarAsync(int id, ModificarEdificio edificio)
        {
            if (edificio == null)
            {
                throw new ArgumentNullException(nameof(edificio));
            }

            var _edificio = await _repositorio.ObtenerAsync(id);
            if (_edificio == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            if (!await _servicioCampus.ExisteAsync(edificio.CampusId))
            {
                throw new NotFoundException(nameof(Campus), edificio.CampusId);
            }

            _mapper.Map(edificio, _edificio);

            await _repositorio.ModificarAsync(_edificio);
        }

        public async Task<EdificioVM> ObtenerAsync(int id)
        {
            var edificio = await _repositorio.ObtenerAsync(id);
            if (edificio == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            return _mapper.Map<EdificioVM>(edificio);
        }

        public async Task<List<EdificioVM>> ObtenerTodosAsync()
        {
            var edificios = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<List<EdificioVM>>(edificios);
        }
    }
}