using AutoMapper;
using Espacios.Core.Binding.Reservaciones;
using Espacios.Core.Entidades;
using Espacios.Core.Excepciones;
using Espacios.Core.Interfaces;
using Espacios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Espacios.Core.Servicios
{
    public class ServicioReservaciones : IServicioReservaciones
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<Reservacion> _repositorio;
        private readonly IServicioSala _servicioSala;
        private readonly string _tipoEntidad = nameof(Reservacion);

        public ServicioReservaciones(
            IMapper mapper,
            IRepositorioBase<Reservacion> repositorio,
            IServicioSala servicioSala)
        {
            _mapper = mapper;
            _repositorio = repositorio;
            _servicioSala = servicioSala;
        }

        public async Task<ReservacionesVM> AgregarAsync(AgregarReservacion reservacion)
        {
            if (reservacion == null)
            {
                throw new ArgumentNullException(nameof(reservacion));
            }

            await VerificarDependencias(reservacion.SalaId);

            var _reservacion = _mapper.Map<Reservacion>(reservacion);

            await _repositorio.AgregarAsync(_reservacion);

            return _mapper.Map<ReservacionesVM>(_reservacion);
        }

        public async Task EliminarAsync(int id)
        {
            var reservacion = await _repositorio.ObtenerAsync(id);
            if (reservacion == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await _repositorio.EliminarAsync(reservacion);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repositorio.ExisteAsync(id);
        }

        public async Task ModificarAsync(int id, ModificarReservacion reservacion)
        {
            if (reservacion == null)
            {
                throw new ArgumentNullException(nameof(reservacion));
            }

            var _reservacion = await _repositorio.ObtenerAsync(id);
            if (_reservacion == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            await VerificarDependencias(reservacion.SalaId);

            _mapper.Map(reservacion, _reservacion);

            await _repositorio.ModificarAsync(_reservacion);
        }

        public async Task<ReservacionesVM> ObtenerAsync(int id)
        {
            var reservacion = await _repositorio.ObtenerAsync(id);
            if (reservacion == null)
            {
                throw new NotFoundException(_tipoEntidad, id);
            }

            return _mapper.Map<ReservacionesVM>(reservacion);
        }

        public async Task<List<ReservacionesVM>> ObtenerTodosAsync()
        {
            var reservacion = await _repositorio.ObtenerTodosAsync();
            return _mapper.Map<List<ReservacionesVM>>(reservacion);
        }

        private async Task VerificarDependencias(int salaId)
        {
            if (!await _servicioSala.ExisteAsync(salaId))
            {
                throw new NotFoundException(nameof(Sala), salaId);
            }
        }
    }
}