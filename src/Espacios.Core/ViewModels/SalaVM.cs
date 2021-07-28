namespace Espacios.Core.ViewModels
{
    public class SalaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Capacidad { get; set; }
        public int EdificioId { get; set; }
    }
}