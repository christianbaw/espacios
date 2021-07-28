using Espacios.Core.Binding.Campus;
using Espacios.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Espacios.Api.Controllers
{
    public class CampusController : ControladorBase
    {
        private readonly IServicioCampus _servicio;

        public CampusController(IServicioCampus servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarCampus campus)
        {
            var _campus = await _servicio.AgregarAsync(campus);
            return CreatedAtAction("ObtenerCampus", new { id = _campus.Id }, _campus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _servicio.EliminarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, ModificarCampus campus)
        {
            await _servicio.ModificarAsync(id, campus);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var campus = await _servicio.ObtenerTodosAsync();
            return Ok(campus);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCampus(int id)
        {
            var campus = await _servicio.ObtenerAsync(id);
            return Ok(campus);
        }
    }
}