using System;
using System.ComponentModel.DataAnnotations;

namespace Espacios.Core.Binding.Edificios
{
    public class EdificioBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, int.MaxValue)]
        public int CampusId { get; set; }
    }
}