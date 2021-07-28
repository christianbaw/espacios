using System.Collections.Generic;
using System.Linq;

namespace Espacios.Core.Entidades
{
    public class Sala : EntidadBase
    {
        public Sala()
        {
            Reservaciones = new HashSet<Reservacion>();
            Equipamientos = new HashSet<SalaEquipamiento>();
        }

        public string Nombre { get; set; }
        public int? Capacidad { get; set; }
        public int EdificioId { get; set; }
        public Edificio Edificio { get; set; }
        public ICollection<Reservacion> Reservaciones { get; private set; }
        public ICollection<SalaEquipamiento> Equipamientos { get; private set; }

        public void AgregarEquipamiento(int equipamientoId)
        {
            if (!Equipamientos.Any(x => x.EquipamientoId == equipamientoId))
            {
                Equipamientos.Add(new SalaEquipamiento { EquipamientoId = equipamientoId });
            }
        }
    }
}