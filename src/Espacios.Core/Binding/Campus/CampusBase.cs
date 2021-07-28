using System;
using System.ComponentModel.DataAnnotations;

namespace Espacios.Core.Binding.Campus
{
    public class CampusBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, int.MaxValue)]
        public int UnidadId { get; set; }
    }
}