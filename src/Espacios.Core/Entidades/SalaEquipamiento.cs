namespace Espacios.Core.Entidades
{
    public class SalaEquipamiento
    {
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
        public int EquipamientoId { get; set; }
        public Equipamiento Equipamiento { get; set; }
    }
}