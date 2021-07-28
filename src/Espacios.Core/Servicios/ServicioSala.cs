using AutoMapper;
using Espacios.Core.Binding.Salas;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Servicios
{
    public class ServicioSala : IServicioSala
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<Sala> _repositorio;
        private readonly IServicioEdificio _servicioEdificio;
        private readonly string _tipoEntidad = nameof(Sala);

        public ServicioSala(
            IMapper mapper,
            IRepositorioBase<Sala> repositorio,
            IServicioEdificio servicioEdificio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _servicioEdificio = servicioEdificio;
        }

        public async Task<SalaVM> AgregarAsync(AgregarSala sala)
        {
            if (sala == null)
            {
                throw new ArgumentNullException(nameof(sala));
            }

            await VerificarDependencias(sala.EdificioId);

            var _sala = _mapper.Map<Sala>(sala);

            await _repositorio.AgregarAsync(_sala);

            return _mapper.Map<SalaVM>(_sala);
        }

        public async Task EliminarAsync(int id)
        {
            var sala = await _repositorio.ObtenerAsync(id);
            if (sala == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await _repositorio.EliminarAsync(sala);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task ModificarAsync(int id, ModificarSala sala)
        {
            if (sala == null)
            {
                throw new ArgumentNullException(nameof(sala));
            }

            var _sala = await _repositorio.ObtenerAsync(id);
            if (_sala == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await VerificarDependencias(sala.EdificioId);

            _mapper.Map(sala, _sala);

            await _repositorio.ModificarAsync(_sala);
        }

        public async Task<SalaVM> ObtenerAsync(int id)
        {
            var sala = await _repositorio.ObtenerAsync(id);
            if (sala == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            return _mapper.Map<SalaVM>(sala);
        }

        public async Task<List<SalaVM>> ObtenerTodosAsync()
        {
            var salas = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<List<SalaVM>>(salas);
        }

        private async Task VerificarDependencias(int edificioId)
        {
            if (!await _servicioEdificio.ExisteAsync(edificioId))
            {
                throw new NotFoundException(nameof(Edificio), edificioId);
            }
        }
    }
}