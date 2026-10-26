namespace Proyecto_Expertos.Domain.Entities
{
    public class Transmision
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int NumeroMarchas { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}