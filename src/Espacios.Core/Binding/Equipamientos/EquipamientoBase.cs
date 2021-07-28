using System.ComponentModel.DataAnnotations;

namespace Espacios.Core.Binding.Equipamientos
{
    public class EquipamientoBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}