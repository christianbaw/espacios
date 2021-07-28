using System;

namespace Espacios.Core.Excepciones
{
    public class NotFoundException : Exception
    {
        public NotFoundException(object id) : base($"Entidad no encontrada (id: {id})")
        {
        }

        public NotFoundException(string entidad, object id) : base($"{entidad} no encontrada (id: {id})")
        {
        }
    }
}