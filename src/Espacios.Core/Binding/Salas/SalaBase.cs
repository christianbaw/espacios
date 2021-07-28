using System.ComponentModel.DataAnnotations;

namespace Espacios.Core.Binding.Salas
{
    public class SalaBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int? Capacidad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, int.MaxValue)]
        public int EdificioId { get; set; }
    }
}