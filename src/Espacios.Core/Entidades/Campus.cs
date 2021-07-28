using System.Collections.Generic;

namespace Espacios.Core.Entidades
{
    public class Campus : EntidadBase
    {
        public Campus()
        {
            Edificios = new HashSet<Edificio>();
        }

        public string Nombre { get; set; }
        public int UnidadId { get; set; }
        public Unidad Unidad { get; set; }
        public ICollection<Edificio> Edificios { get; private set; }
    }
}