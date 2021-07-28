using Espacios.Core.Binding.Unidades;
using Espacios.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Espacios.Api.Controllers
{
    public class UnidadesController : ControladorBase
    {
        private readonly IServicioUnidad _servicio;

        public UnidadesController(IServicioUnidad servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarUnidad unidad)
        {
            var _unidad = await _servicio.AgregarAsync(unidad);
            return CreatedAtAction("ObtenerUnidad", new { id = _unidad.Id }, _unidad);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _servicio.EliminarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, ModificarUnidad unidad)
        {
            await _servicio.ModificarAsync(id, unidad);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var unidades = await _servicio.ObtenerTodosAsync();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUnidad(int id)
        {
            var unidad = await _servicio.ObtenerAsync(id);
            return Ok(unidad);
        }
    }
}