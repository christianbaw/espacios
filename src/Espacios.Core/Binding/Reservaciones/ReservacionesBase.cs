using Espacios.Core.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Espacios.Core.Binding.Reservaciones
{
    public class ReservacionesBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, int.MaxValue)]
        public int SalaId { get; set; }

        public string Adicionales { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [EnumDataType(typeof(EstatusEnum))]
        public EstatusEnum Estatus { get; set; }
    }
}
