using System.Collections.Generic;

namespace Espacios.Core.Entidades
{
    public class Edificio : EntidadBase
    {
        public Edificio()
        {
            Salas = new HashSet<Sala>();
        }

        public string Nombre { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
        public ICollection<Sala> Salas { get; private set; }
    }
}