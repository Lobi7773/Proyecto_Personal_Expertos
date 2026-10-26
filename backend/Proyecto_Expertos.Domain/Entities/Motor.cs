namespace Proyecto_Expertos.Domain.Entities
{
    public class Motor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public decimal CilindradaLitros { get; set; }
        public int NumeroCilindros { get; set; }
        public string TipoCombustible { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}