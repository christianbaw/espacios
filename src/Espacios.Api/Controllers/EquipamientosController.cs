using Espacios.Core.Binding.Equipamientos;
using Espacios.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Espacios.Api.Controllers
{
    public class EquipamientosController : ControladorBase
    {
        private readonly IServicioEquipamiento _servicioEquipamiento;

        public EquipamientosController(IServicioEquipamiento servicioEquipamiento)
        {
            _servicioEquipamiento = servicioEquipamiento;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarEquipamiento equipamiento)
        {
            var _equipamiento = await _servicioEquipamiento.AgregarAsync(equipamiento);
            return CreatedAtAction("Obtener", new { id = _equipamiento.Id }, _equipamiento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _servicioEquipamiento.EliminarAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, ModificarEquipamiento equipamiento)
        {
            await _servicioEquipamiento.ModificarAsync(id, equipamiento);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var equpamiento = await _servicioEquipamiento.ObtenerAsync(id);
            return Ok(equpamiento);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var equipamientos = await _servicioEquipamiento.ObtenerTodosAsync();
            return Ok(equipamientos);
        }
    }
}