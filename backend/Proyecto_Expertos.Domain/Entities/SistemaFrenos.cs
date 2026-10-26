namespace Proyecto_Expertos.Domain.Entities
{
    public class SistemaFrenos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Eje { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}