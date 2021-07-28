using Espacios.Core.Binding.Salas;
using Espacios.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Espacios.Api.Controllers
{
    public class SalasController : ControladorBase
    {
        private readonly IServicioSala _servicioSala;

        public SalasController(IServicioSala servicioSala)
        {
            _servicioSala = servicioSala;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarSala sala)
        {
            var _sala = await _servicioSala.AgregarAsync(sala);
            return CreatedAtAction("Obtener", new { id = _sala.Id }, _sala);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _servicioSala.EliminarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, ModificarSala sala)
        {
            await _servicioSala.ModificarAsync(id, sala);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var sala = await _servicioSala.ObtenerAsync(id);
            return Ok(sala);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var salas = await _servicioSala.ObtenerTodosAsync();
            return Ok(salas);
        }
    }
}