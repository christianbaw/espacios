using System;

namespace Espacios.Core.Entidades
{
    public class Reservacion : EntidadBase
    {
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Adicionales { get; set; }
        public EstatusEnum Estatus { get; set; }
    }
}