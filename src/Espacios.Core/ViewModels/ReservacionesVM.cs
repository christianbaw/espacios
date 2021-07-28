using Espacios.Core.Entidades;
using System;

namespace Espacios.Core.ViewModels
{
    public class ReservacionesVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int SalaId { get; set; }
        public string Adicionales { get; set; }
        public EstatusEnum Estatus { get; set; }
    }
}
