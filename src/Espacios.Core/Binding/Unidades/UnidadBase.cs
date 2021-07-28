using System.ComponentModel.DataAnnotations;

namespace Espacios.Core.Binding.Unidades
{
    public class UnidadBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}