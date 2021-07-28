using System.Collections.Generic;

namespace Espacios.Core.Entidades
{
    public class Unidad : EntidadBase
    {
        public Unidad()
        {
            Campus = new HashSet<Campus>();
        }

        public string Nombre { get; set; }
        public ICollection<Campus> Campus { get; private set; }
    }
}