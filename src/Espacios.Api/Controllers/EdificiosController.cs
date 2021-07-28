using Espacios.Core.Binding.Edificios;
using Espacios.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Espacios.Api.Controllers
{
    public class EdificiosController : ControladorBase
    {
        private readonly IServicioEdificio _servicioEdificio;

        public EdificiosController(IServicioEdificio servicioEdificio)
        {
            _servicioEdificio = servicioEdificio;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarEdificio edificio)
        {
            var _edificio = await _servicioEdificio.AgregarAsync(edificio);
            return CreatedAtAction("Obtener", new { id = _edificio.Id }, _edificio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _servicioEdificio.EliminarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, ModificarEdificio edificio)
        {
            await _servicioEdificio.ModificarAsync(id, edificio);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var edificio = await _servicioEdificio.ObtenerAsync(id);
            return Ok(edificio);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var edificios = await _servicioEdificio.ObtenerTodosAsync();
            return Ok(edificios);
        }
    }
}