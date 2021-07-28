using Espacios.Core.Binding.Reservaciones;
using Espacios.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Espacios.Api.Controllers
{
    public class ReservacionesController : ControladorBase
    {
        private readonly IServicioReservaciones _servicioReservaciones;

        public ReservacionesController(IServicioReservaciones servicioReservaciones)
        {
            _servicioReservaciones = servicioReservaciones;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarReservacion reservacion)
        {
            var _reservaciones = await _servicioReservaciones.AgregarAsync(reservacion);
            return CreatedAtAction("Obtener", new { id = _reservaciones.Id }, _reservaciones);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _servicioReservaciones.EliminarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, ModificarReservacion reservacion)
        {
            await _servicioReservaciones.ModificarAsync(id, reservacion);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var reservacion = await _servicioReservaciones.ObtenerAsync(id);
            return Ok(reservacion);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var reservaciones = await _servicioReservaciones.ObtenerTodosAsync();
            return Ok(reservaciones);
        }
    }
}